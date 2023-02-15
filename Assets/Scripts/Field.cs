using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : Building
{
  public Crop crop;
  public int daysSincePlanted;
  public bool isWatered;

  private void Start()
  {
    TimeManager.OnDayChanged += AddDay;
  }
  private void AddDay()
  {
    daysSincePlanted++;
  }

  public override void OnPlace()
  {

  }
}