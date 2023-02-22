using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DraggableSlotContentUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  public int slotIndex;
  [HideInInspector] public Transform parentAfterDrag;
  public Image image;
  public void OnBeginDrag(PointerEventData eventData)
  {
    Debug.Log("Start Drag");

    parentAfterDrag = transform.parent;
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
    Debug.Log("End drag");
    transform.SetParent(parentAfterDrag);
    image.raycastTarget = true;
    // invoke
    Inventory.OnPlayerInventoryChanged?.Invoke();
  }
}