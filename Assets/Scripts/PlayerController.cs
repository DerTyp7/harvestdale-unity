using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

  public static Action OnActiveSlotChanged;
  public Item testItem1;
  public Item testItem2;

  public int hotbarSlotCount = 9;
  public int activeHotbarSlot = 0;
  [SerializeField] private Inventory playerInventory;

  // Start is called before the first frame update
  void Start()
  {
    playerInventory = GetComponent<Inventory>();
    GuiManager.Instance.OpenPanel("Hotbar");
  }

  // Update is called once per frame
  void Update()
  {
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    if (scroll != 0)
    {
      activeHotbarSlot += (int)Mathf.Sign(scroll);
      if (activeHotbarSlot < 0)
      {
        activeHotbarSlot = hotbarSlotCount - 1;
      }
      else if (activeHotbarSlot >= hotbarSlotCount)
      {
        activeHotbarSlot = 0;
      }
      OnActiveSlotChanged?.Invoke();
    }

    if (Input.GetKeyDown(KeyCode.Tab))
    {
      GuiManager.Instance.TogglePanel("Inventory");
    }

    //! DEBUG
    if (Input.GetKeyDown(KeyCode.U))
    {
      // add 5 apples
      int remainingCount = playerInventory.Add(testItem1, 5);
      Debug.Log("Added " + (5 - remainingCount) + " apples to playerInventory.");
    }

    if (Input.GetKeyDown(KeyCode.I))
    { // add 15 more apples
      int remainingCount = playerInventory.Add(testItem1, 15);
      Debug.Log("Added " + (15 - remainingCount) + " apples to playerInventory.");
    }

    if (Input.GetKeyDown(KeyCode.O))
    {
      // add 10 bananas
      int remainingCount = playerInventory.Add(testItem2, 10);
      Debug.Log("Added " + (10 - remainingCount) + " bananas to playerInventory.");
    }


    if (Input.GetKeyDown(KeyCode.J))
    {
      int count = 3;
      int applesRemaining = playerInventory.Remove(testItem1, count);
      Debug.Log("Removed " + (count - applesRemaining) + " apples.");

    }

    if (Input.GetKeyDown(KeyCode.K))
    {
      int count = 5;
      int bananasRemaining = playerInventory.Remove(testItem2, count);
      Debug.Log("Removed " + (count - bananasRemaining) + " bananas.");

    }


  }
}
