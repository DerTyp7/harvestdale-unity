using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// represents an item in the inventory and its count
[System.Serializable]
public class InventoryItem<TItem> where TItem : Item
{
  public TItem item;
  public int count;

  public InventoryItem(TItem item, int count)
  {
    this.item = item;
    this.count = count;
  }
}