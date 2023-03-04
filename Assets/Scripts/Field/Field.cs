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
  public Crop crop;

  public SpriteRenderer currentCropSpriteRenderer;
  public int daysSincePlanted;
  public bool isWatered = false;
  public FieldState state = FieldState.EMPTY;


  private void Start()
  {
    TimeManager.OnDayChanged += AddDay;

  }

  private void SetSprite(Sprite sprite)
  {
    if (currentCropSpriteRenderer)
    {
      currentCropSpriteRenderer.sprite = sprite;
      currentCropSpriteRenderer.drawMode = SpriteDrawMode.Tiled;
      currentCropSpriteRenderer.size = new Vector2(10, 10); // TODO: Make this dynamic
    }
  }


  private void AddDay()
  {
    if (crop && isPlaced && state != FieldState.DEAD)
    {
      if (!isWatered)
        state = FieldState.DEAD;
      else
      {
        daysSincePlanted++;
        SetSprite(crop.sprites[daysSincePlanted]);
      }

    }
  }

  public void Plant(Crop newCrop)
  {
    daysSincePlanted = 0;
    state = FieldState.GROWING;
    crop = newCrop;
    SetSprite(crop.sprites[0]);

  }

  public override void OnPlace()
  {
    Plant(null);
  }
}