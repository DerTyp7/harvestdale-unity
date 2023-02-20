using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public Item testItem1;
  public Item testItem2;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Inventory inventory = GetComponent<Inventory>();

    if (Input.GetKeyDown(KeyCode.U))
    {
      // add 5 apples
      int remainingCount = inventory.Add(testItem1, 5);
      Debug.Log("Added " + (5 - remainingCount) + " apples to inventory.");
    }

    if (Input.GetKeyDown(KeyCode.I))
    { // add 15 more apples
      int remainingCount = inventory.Add(testItem1, 15);
      Debug.Log("Added " + (15 - remainingCount) + " apples to inventory.");
    }

    if (Input.GetKeyDown(KeyCode.O))
    {
      // add 10 bananas
      int remainingCount = inventory.Add(testItem2, 10);
      Debug.Log("Added " + (10 - remainingCount) + " bananas to inventory.");
    }


    if (Input.GetKeyDown(KeyCode.J))
    {
      int count = 3;
      int applesRemaining = inventory.Remove(testItem1, count);
      Debug.Log("Removed " + (count - applesRemaining) + " apples.");

    }

    if (Input.GetKeyDown(KeyCode.K))
    {
      int count = 5;
      int bananasRemaining = inventory.Remove(testItem2, count);
      Debug.Log("Removed " + (count - bananasRemaining) + " bananas.");

    }


  }
}
