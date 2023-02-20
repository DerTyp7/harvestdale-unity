using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Crop", menuName = "Harvestdale/Items/Crop", order = 0)]
public class Crop : Item
{
  public int daysToGrow;
  public List<Sprite> sprites = new List<Sprite>();
}