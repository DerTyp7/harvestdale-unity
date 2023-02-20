using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// represents an item in the inventory and its count
[System.Serializable]
public class InventoryItem
{
  public Item item;
  public int count;

  public InventoryItem(Item item, int count)
  {
    this.item = item;
    this.count = count;
  }
}