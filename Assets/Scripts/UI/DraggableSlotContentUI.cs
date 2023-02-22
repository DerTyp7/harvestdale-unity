using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableSlotContentUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  public int slotIndex; // slotIndex is set by SlotUI
  [HideInInspector] public Transform parentAfterDrag;
  public Image image;
  public void OnBeginDrag(PointerEventData eventData)
  {
    parentAfterDrag = transform.parent;
    slotIndex = parentAfterDrag.GetComponent<SlotUI>().slotIndex; // Set slotIndex again to be safe, but should be already set
    transform.SetParent(transform.root);
    transform.SetAsLastSibling();
    image.raycastTarget = false;
  }

  public void OnDrag(PointerEventData eventData)
  {
    Debug.Log("Dragging");
    transform.position = Input.mousePosition;

  }

  public void OnEndDrag(PointerEventData eventData)
  {
    transform.SetParent(parentAfterDrag);
    image.raycastTarget = true;
    // invoke
    Inventory.OnPlayerInventoryChanged?.Invoke();
  }
}