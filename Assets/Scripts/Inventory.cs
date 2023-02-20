using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
  public int maxSlots = 20; // maximum number of slots in the inventory
  public List<InventoryItem> items = new List<InventoryItem>(); // list of items in the inventory

  // adds an item to the inventory, returns the quantity of items which could not be added
  public int Add(Item item, int count)
  {
    int remainingCount = count;

    // check if the item is stackable
    if (item.stackable)
    {
      // look for an existing stack of the same item in the inventory
      foreach (InventoryItem invItem in items)
      {
        if (invItem.item == item && invItem.count < item.maxStackSize)
        {
          // add as many items as possible to the stack
          int space = item.maxStackSize - invItem.count;
          int toAdd = Mathf.Min(space, remainingCount);
          invItem.count += toAdd;
          remainingCount -= toAdd;

          // exit the loop if all items have been added
          if (remainingCount == 0)
          {
            return 0;
          }
        }
      }
    }

    // if there is still remaining count, add new stacks of the item
    while (remainingCount > 0 && items.Count < maxSlots)
    {
      int toAdd = Mathf.Min(item.maxStackSize, remainingCount);
      items.Add(new InventoryItem(item, toAdd));
      remainingCount -= toAdd;
    }

    // return the quantity of items which could not be added
    return remainingCount;
  }


  // removes an item from the inventory, returns the quantity of items which could not be removed
  public int Remove(Item item, int count)
  {
    int remainingCount = count;

    // look for an existing stack of the item in the inventory
    for (int i = 0; i < items.Count; i++)
    {
      InventoryItem invItem = items[i];
      if (invItem.item == item)
      {
        // remove as many items as possible from the stack
        int toRemove = Mathf.Min(invItem.count, remainingCount);
        invItem.count -= toRemove;
        remainingCount -= toRemove;

        // remove the stack if it's now empty
        if (invItem.count == 0)
        {
          items.RemoveAt(i);
        }

        // exit the loop if all items have been removed
        if (remainingCount == 0)
        {
          return 0;
        }
      }
    }

    // return the quantity of items which could not be removed
    return remainingCount;
  }
}


