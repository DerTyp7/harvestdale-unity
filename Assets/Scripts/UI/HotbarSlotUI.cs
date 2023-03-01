// using System.Collections;
// using UnityEngine.UI;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// public class HotbarSlotUI : MonoBehaviour
// {
//   public int slotIndex;

//   private PlayerController playerController;

//   private InventoryItem invItem;

//   [SerializeField] private Image border;
//   [SerializeField] private Image image;
//   [SerializeField] private TextMeshProUGUI quantityText;

//   private void Start()
//   {
//     playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
//     PlayerController.OnActiveSlotChanged += CheckSelectedSlot;
//     CheckSelectedSlot();
//   }

//   private void CheckSelectedSlot()
//   {
//     if (playerController.activeHotbarSlot == slotIndex)
//     {
//       border.gameObject.SetActive(true);
//     }
//     else
//     {
//       border.gameObject.SetActive(false);
//     }
//   }

//   public void SetInventoryItem(InventoryItem newInvItem)
//   {
//     invItem = newInvItem;
//     UpdateSlot();
//   }

//   private void UpdateSlot()
//   {
//     image.sprite = invItem?.item?.sprite ?? null;
//     quantityText.SetText(invItem?.count.ToString() ?? "");
//     if (image.sprite == null)
//     {
//       image.color = new Color(0, 0, 0, 0);
//     }
//     else
//     {
//       image.color = Color.white;
//     }
//   }
// }
