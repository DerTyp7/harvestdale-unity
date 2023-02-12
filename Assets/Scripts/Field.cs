using UnityEngine;
public class Field : MonoBehaviour
{
  public Crop crop;
  public int daysSincePlanted;
  public bool isWatered;

  private void Start()
  {
    TimeManager.OnMinuteChanged += logTime;
    TimeManager.OnHourChanged += logTime;
  }
  public void logTime()
  {
    Debug.Log($"{TimeManager.Hour:00}:{TimeManager.Minute:00}");
  }
}