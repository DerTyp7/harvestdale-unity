// Text which is left from the cursor
using UnityEngine;
using TMPro;

public class CursorText : MonoBehaviour
{
  private TextMeshProUGUI textComponent;
  private string text = "";
  private GameObject player;

  private void Start()
  {
    textComponent = GetComponent<TextMeshProUGUI>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  public void SetText(string newText)
  {
    text = newText;
    this.textComponent.SetText(text);
  }

  private void Update()
  {
    if (text.Length > 0)
    {
      // Set gameobject left from cursor
      Vector3 mousePos = Input.mousePosition;
      mousePos.x += 125;
      transform.position = mousePos;
    }


    // if hovering over interactable object
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit2D hit;

    hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Interactable"));

    if (hit.collider != null)
    {
      Interactable interactable = hit.collider.GetComponent<Interactable>();
      if (interactable != null)
      {
        SetText(interactable.GetInteractText(player));
      }
    }
    else
    {
      SetText("");
    }
  }
}