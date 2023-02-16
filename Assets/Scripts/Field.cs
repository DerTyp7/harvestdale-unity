using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : Building
{
  public Crop TESTCROP;
  public Crop crop;

  public SpriteRenderer currentCropSprite;
  public int daysSincePlanted;
  public bool isWatered;
  public bool isDead = false;
  private void Start()
  {
    TimeManager.OnDayChanged += AddDay;
  }
  private void AddDay()
  {
    if (crop && isPlaced && !isDead)
    {
      if (!isWatered)
        isDead = true;
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
    isDead = false;
    crop = newCrop;
  }

  public override void OnPlace()
  {
    daysSincePlanted = 0;
    isDead = false;
    Plant(TESTCROP);
  }
}