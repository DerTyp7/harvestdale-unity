using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Item", menuName = "Harvestdale/Items/Item", order = 0)]
public class Item : ScriptableObject
{
  public string uuid;
  public string itemName;

  public Sprite sprite;
  public bool stackable = true;
  public int maxStackSize = 100;


  private void OnEnable()
  {
    if (!stackable)
    {
      maxStackSize = 1;
    }
  }
}