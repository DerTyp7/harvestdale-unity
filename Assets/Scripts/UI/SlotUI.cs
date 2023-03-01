// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// public class SlotUI : MonoBehaviour, IDropHandler
// {
//   public int slotIndex;
//   [SerializeField] private GameObject contentObject;
//   [SerializeField] private InventoryItem inventoryItem;
//   [SerializeField] private Image itemSpriteImage;
//   [SerializeField] private TMPro.TextMeshProUGUI quantityText;

//   private Inventory playerInventory;
//   private void Start()
//   {
//     UpdateSlot();
//     playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
//   }
//   public void SetInventoryItem(InventoryItem newInventoryItem)
//   {
//     inventoryItem = newInventoryItem;
//     UpdateSlot();
//   }

//   private void UpdateSlot()
//   {
//     if (inventoryItem != null)
//     {
//       itemSpriteImage.sprite = inventoryItem?.item?.sprite ?? null;
//       if (itemSpriteImage.sprite == null)
//       {
//         itemSpriteImage.color = new Color(0, 0, 0, 0);
//       }
//       else
//       {
//         itemSpriteImage.color = new Color(255, 255, 255, 1);
//       }

//       quantityText.SetText(inventoryItem.count != 0 ? inventoryItem.count.ToString() : "");
//     }
//     else
//     {
//       itemSpriteImage.sprite = null;
//       quantityText.SetText("");
//       itemSpriteImage.color = new Color(0, 0, 0, 0);
//     }

//   }



//   public void OnDrop(PointerEventData eventData)
//   {
//     Debug.Log("DROP");
//     DraggableSlotContentUI dropped = eventData.pointerDrag.GetComponent<DraggableSlotContentUI>();
//     playerInventory.SwapItems(dropped.slotIndex, slotIndex);
//   }

// }
