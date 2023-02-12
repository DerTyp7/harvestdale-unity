using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : MonoBehaviour
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
}