// Contains logic for the field
// Checks if a plant is dead, growing or harvestable
// Determines what sprite to show
// Handles planting and harvesting

using UnityEngine;

public enum FieldState
{
  EMPTY,
  DEAD,
  GROWING,
  HARVESTABLE,
}

public class Field : Building
{
  [Header("Children Objects")]
  [SerializeField]
  private SpriteRenderer cropSpriteRenderer;

  [SerializeField]
  private SpriteRenderer backgroundSpriteRenderer;

  [SerializeField]
  private GameObject fieldController;

  [Header("Field Properties")]
  [SerializeField]
  private Crop crop;

  private Vector2Int size;
  private int daysSincePlanted;
  private bool isWatered = false;

  private FieldState state = FieldState.EMPTY;

  public FieldState State
  {
    get { return state; }
  }

  public bool IsWatered
  {
    get { return isWatered; }
  }

  private void Start()
  {
    size = DeterminSize();
    SetFieldControllerPosition();
    fieldController.GetComponent<FieldController>().SetField(this);

    TimeManager.OnDayChanged += DayInterval;
    TimeManager.OnMonthChanged += MonthInterval;
  }

  public override void OnPlace()
  {
    EmptyField();
  }

  private void SetFieldControllerPosition()
  {
    if (fieldController)
    {
      fieldController.transform.localPosition = new Vector3(size.x, size.y / 2, 0);
    }
  }

  private Vector2Int DeterminSize()
  {
    return new Vector2Int(Mathf.FloorToInt(backgroundSpriteRenderer.size.x), Mathf.FloorToInt(backgroundSpriteRenderer.size.y));
  }

  private void SetSprite(Sprite sprite)
  {
    if (cropSpriteRenderer)
    {
      cropSpriteRenderer.sprite = sprite;
      cropSpriteRenderer.drawMode = SpriteDrawMode.Tiled;
      cropSpriteRenderer.size = size;
    }
  }

  private void DayInterval()
  {
    if (state == FieldState.GROWING)
    {
      if (!isWatered)
        state = FieldState.DEAD;
      else
      {
        // SetSprite(crop.Sprites[daysSincePlanted]);
      }
    }
  }

  private void MonthInterval()
  {
    if (state == FieldState.GROWING)
    {
      if (crop.SeasonToHarvest == TimeManager.CurrentSeason)
      {
        state = FieldState.HARVESTABLE;
      }
    }
  }

  #region Field controlling
  public void Plant(Crop newCrop)
  {
    bool enoughItemsInInventory = FarmManager.Instance.CropInventory.RemoveExactAmount(newCrop, size.x * size.y);
    if (enoughItemsInInventory)
    {
      daysSincePlanted = 0;
      state = FieldState.GROWING;
      crop = newCrop;
      SetSprite(crop.Sprites[0]);
    }
    else
    {
      Debug.Log("Not enough items in inventory");
    }

  }

  public void Harvest()
  {
    if (state == FieldState.HARVESTABLE)
    {
      FarmManager.Instance.HarvestInventory.Add(crop.HarvestItem, size.x * size.y);
      state = FieldState.EMPTY;
      SetSprite(null);
    }
  }

  public void Water()
  {
    isWatered = true;
  }

  public void UnWater()
  {
    isWatered = false;
  }

  public void EmptyField()
  {
    state = FieldState.EMPTY;
    SetSprite(null);
  }
  #endregion
}