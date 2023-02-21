using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
  [SerializeField] private InventoryItem inventoryItem;
  [SerializeField] private Image itemSpriteImage;
  [SerializeField] private TMPro.TextMeshProUGUI quantityText;

  private void Start()
  {
    UpdateSlot();
  }
  public void SetInventoryItem(InventoryItem newInventoryItem)
  {
    inventoryItem = newInventoryItem;
    UpdateSlot();
  }

  private void UpdateSlot()
  {
    if (inventoryItem != null)
    {
      itemSpriteImage.sprite = inventoryItem?.item?.sprite ?? null;
      Debug.Log(itemSpriteImage.sprite);
      if (itemSpriteImage.sprite == null)
      {
        itemSpriteImage.color = new Color(0, 0, 0, 0);
      }

      quantityText.SetText(inventoryItem.count != 0 ? inventoryItem.count.ToString() : "");
    }
    else
    {
      itemSpriteImage.sprite = null;
      quantityText.SetText("");
      itemSpriteImage.color = new Color(0, 0, 0, 0);
    }

  }

}
