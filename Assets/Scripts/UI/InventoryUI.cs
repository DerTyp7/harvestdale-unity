using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
  [SerializeField] private GameObject slotPrefab;
  [SerializeField] private GameObject slotListObj;
  [SerializeField] private List<SlotUI> slotUIList;

  private Inventory playerInventory;

  private void Start()
  {
    playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    Inventory.OnPlayerInventoryChanged += UpdateSlots;
    CreateSlots();
    UpdateSlots();

  }

  private void CreateSlots()
  {
    playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    for (int i = 0; i < playerInventory.maxSlots; i++)
    {
      slotUIList.Add(Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotListObj.transform).GetComponent<SlotUI>());
    }
  }
  private void UpdateSlots()
  {
    Debug.Log("Update slots");
    int i = 0;
    foreach (SlotUI slotUi in slotUIList)
    {
      if (i < playerInventory.items.Count)
      {
        slotUi.SetInventoryItem(playerInventory.items[i]);
      }
      else
      {
        slotUi.SetInventoryItem(null);
      }

      i++;
    }
  }

}
