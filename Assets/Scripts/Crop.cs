using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "Harvestdale/Crops", order = 0)]
public class Crop : ScriptableObject
{
  public string cropName;
  public int daysToGrow;
  public bool isHarvestable;
}