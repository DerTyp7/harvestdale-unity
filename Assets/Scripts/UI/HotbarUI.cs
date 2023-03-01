// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class HotbarUI : GuiPanel
// {
//   [SerializeField] private GameObject hotbarSlotPrefab;
//   private List<HotbarSlotUI> slots = new List<HotbarSlotUI>();
//   private Inventory playerInventory;
//   private PlayerController playerController;
//   private int hotbarSlotCount = 9;

//   private void Start()
//   {
//     Inventory.OnPlayerInventoryChanged += UpdateSlots;
//   }
//   public override void OnOpen()
//   {
//     if (slots.Count == 0)
//     {
//       playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
//       playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
//       hotbarSlotCount = playerController.hotbarSlotCount;
//       CreateSlots();
//     }
//     UpdateSlots();
//   }

//   public override void OnClose()
//   {
//   }

//   private void CreateSlots()
//   {
//     for (int i = 0; i < hotbarSlotCount; i++)
//     {
//       HotbarSlotUI newSlot = Instantiate(hotbarSlotPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<HotbarSlotUI>();
//       newSlot.slotIndex = i;
//       slots.Add(newSlot);
//     }
//   }

//   private void UpdateSlots()
//   {
//     for (int i = 0; i < slots.Count; i++)
//     {
//       slots[i].SetInventoryItem(playerInventory.items[i] ?? null);
//     }
//   }

// }
