using UnityEngine;
using System;

[System.Serializable]
public class Inventory<TItem> where TItem : Item
{
  [SerializeField]
  private int maxSlots;
  public int maxStackSize;

  [SerializeField]
  private InventoryItem<TItem>[] items;

  public Inventory(int maxSlots = 1, int maxStackSize = 100)
  {
    this.maxSlots = maxSlots;
    this.maxStackSize = maxStackSize;
    items = new InventoryItem<TItem>[maxSlots];
    generateEmtpySlots();
  }

  public void setMaxSlots(int newMaxSlots)
  {
    maxSlots = newMaxSlots;
    generateEmtpySlots();
  }

  private void generateEmtpySlots()
  {
    for (int i = items.Length > 0 ? items.Length - 1 : 0; i < maxSlots; i++)
    {
      items[i] = null;
    }
  }
  // adds an item to the inventory, returns the quantity of items which could not be added
  public int Add(TItem item, int count)
  {
    int remainingCount = count;

    // check if the item is stackable
    if (item.stackable)
    {

      // look for an existing stack of the same item in the inventory
      for (int i = 0; i < items.Length; i++)
      {
        InventoryItem<TItem> invItem = items[i];
        if (invItem != null && invItem.item == item && invItem.count < maxStackSize)
        {
          // add as many items as possible to the stack
          int space = maxStackSize - invItem.count;
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
    for (int i = 0; i < items.Length; i++)

    {
      InventoryItem<TItem> invItem = items[i];
      Debug.Log(invItem);
      if (invItem?.item == null)
      {

        int toAdd = Mathf.Min(maxStackSize, remainingCount);
        items[i] = new InventoryItem<TItem>(item, toAdd);
        remainingCount -= toAdd;

        // exit the loop if all items have been added
        if (remainingCount == 0)
        {
          return 0;
        }
      }
    }

    return remainingCount;
  }


  // removes an item from the inventory, returns the quantity of items which could not be removed
  public int Remove(Item item, int count)
  {
    int remainingCount = count;

    // look for an existing stack of the item in the inventory
    for (int i = 0; i < items.Length; i++)
    {
      InventoryItem<TItem> invItem = items[i];
      if (invItem != null && invItem.item == item)
      {
        // remove as many items as possible from the stack
        int toRemove = Mathf.Min(invItem.count, remainingCount);
        invItem.count -= toRemove;
        remainingCount -= toRemove;

        // remove the stack if it's now empty
        if (invItem.count == 0)
        {
          items[i] = null;
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

  public void SwapItems(int index1, int index2)
  {
    InventoryItem<TItem> temp = items[index1];
    items[index1] = items[index2];
    items[index2] = temp;
  }
}


