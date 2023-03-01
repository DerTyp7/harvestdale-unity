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
  public Crop TESTCROP;
  public Crop crop;

  public SpriteRenderer currentCropSprite;
  public int daysSincePlanted;
  public bool isWatered = false;
  public FieldState state = FieldState.EMPTY;


  private void Start()
  {
    TimeManager.OnDayChanged += AddDay;
    //! DEBUG
    OnPlace();
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
        currentCropSprite.sprite = crop.sprites[daysSincePlanted];
      }

    }
  }

  public void Plant(Crop newCrop)
  {
    daysSincePlanted = 0;
    state = FieldState.GROWING;
    crop = newCrop;
  }

  public override void OnPlace()
  {
    daysSincePlanted = 0;
    state = FieldState.GROWING;
    Plant(TESTCROP);
  }
}