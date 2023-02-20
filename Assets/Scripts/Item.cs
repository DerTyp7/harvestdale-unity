using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Item", menuName = "Harvestdale/Items/Item", order = 0)]
public class Item : ScriptableObject
{
  public string uuid;
  public string itemName;

  public int quantity = 1;
}