// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class InventoryUI : GuiPanel
// {
//   [SerializeField] private GameObject slotPrefab;
//   [SerializeField] private GameObject slotListObj;
//   [SerializeField] private List<SlotUI> slotUIList;

//   private Inventory playerInventory;

//   private void Start()
//   {
//     Inventory.OnPlayerInventoryChanged += UpdateSlots;
//   }
//   public override void OnOpen()
//   {
//     if (slotUIList.Count == 0)
//     {
//       playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
//       CreateSlots();
//     }
//     UpdateSlots();
//     GuiManager.Instance.ClosePanel("Hotbar");
//   }

//   public override void OnClose()
//   {
//     GuiManager.Instance.OpenPanel("Hotbar");
//   }
//   private void CreateSlots()
//   {
//     playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

//     for (int i = 0; i < playerInventory.maxSlots; i++)
//     {
//       SlotUI newSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotListObj.transform).GetComponent<SlotUI>();
//       newSlot.slotIndex = i;
//       slotUIList.Add(newSlot);
//     }
//   }
//   private void UpdateSlots()
//   {
//     int i = 0;
//     foreach (SlotUI slotUi in slotUIList)
//     {
//       slotUi.SetInventoryItem(playerInventory.items[i]);
//       i++;
//     }
//   }

// }
