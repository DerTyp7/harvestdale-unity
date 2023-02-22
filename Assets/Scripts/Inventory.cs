using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
  public static Action OnPlayerInventoryChanged;

  public bool isPlayerInventory = false;
  public int maxSlots = 20; // maximum number of slots in the inventory
  public InventoryItem[] items; // list of items in the inventory


  private void Awake()
  {
    items = new InventoryItem[maxSlots];
    for (int i = 0; i < maxSlots; i++)
    {
      items[i] = null;
    }
  }

  // adds an item to the inventory, returns the quantity of items which could not be added
  public int Add(Item item, int count)
  {
    int remainingCount = count;

    // check if the item is stackable
    if (item.stackable)
    {

      // look for an existing stack of the same item in the inventory
      for (int i = 0; i < items.Length; i++)
      {
        InventoryItem invItem = items[i];
        if (invItem != null && invItem.item == item && invItem.count < item.maxStackSize)
        {
          // add as many items as possible to the stack
          int space = item.maxStackSize - invItem.count;
          int toAdd = Mathf.Min(space, remainingCount);
          invItem.count += toAdd;
          remainingCount -= toAdd;

          // exit the loop if all items have been added
          if (remainingCount == 0)
          {
            if (isPlayerInventory)
            {
              OnPlayerInventoryChanged?.Invoke();
            }

            return 0;
          }
        }
      }
    }

    // if there is still remaining count, add new stacks of the item
    for (int i = 0; i < items.Length; i++)

    {
      InventoryItem invItem = items[i];
      Debug.Log(invItem);
      if (invItem.item == null)
      {

        int toAdd = Mathf.Min(item.maxStackSize, remainingCount);
        items[i] = new InventoryItem(item, toAdd);
        remainingCount -= toAdd;

        // exit the loop if all items have been added
        if (remainingCount == 0)
        {

          if (isPlayerInventory)
          {
            OnPlayerInventoryChanged?.Invoke();
          }

          return 0;
        }
      }
    }

    // return the quantity of items which could not be added
    if (isPlayerInventory)
    {
      OnPlayerInventoryChanged?.Invoke();
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
      InventoryItem invItem = items[i];
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
          if (isPlayerInventory)
          {
            OnPlayerInventoryChanged?.Invoke();
          }
          return 0;
        }
      }
    }

    // return the quantity of items which could not be removed
    if (isPlayerInventory)
    {
      OnPlayerInventoryChanged?.Invoke();
    }
    return remainingCount;
  }

  public void SwapItems(int index1, int index2)
  {
    InventoryItem temp = items[index1];
    items[index1] = items[index2];
    items[index2] = temp;
    if (isPlayerInventory)
    {
      OnPlayerInventoryChanged?.Invoke();
    }
  }
}


