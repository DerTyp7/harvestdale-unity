using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Crop", menuName = "Harvestdale/Crops", order = 0)]
public class Crop : ScriptableObject
{
  public string cropName;
  public int daysToGrow;
  public List<Sprite> sprites = new List<Sprite>();
}