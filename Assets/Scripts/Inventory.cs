using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  [SerializeField] private int slots = 10;
  [SerializeField] private int stackSize = 100;
  [SerializeField] private List<Item> items = new List<Item>();


  public Item Add(Item item)
  {
    foreach (Item i in items)
    {
      if (i.uuid == item.uuid) // item already is in list
      {
        if (i.quantity + item.quantity <= stackSize)
        {// enough space
          i.quantity += item.quantity;
          item.quantity = 0;
        }
        else
        {// Not enough space
          i.quantity = stackSize;
          item.quantity = Mathf.Max(0, i.quantity - item.quantity);
        }
      }
    }
    return item;

  }

}
