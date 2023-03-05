// Base class for interactable object in the top-down game
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
  [SerializeField]
  [Range(0f, 10f)]
  private float radius = 2f; // radius of interaction

  public abstract string interactText { get; } // text to display when player is in range

  [SerializeField]
  private string interactTextOutOfRange = "Out of range"; // text to display when player is out of range

  public string GetInteractText(GameObject interactor = null)
  {
    if (interactor != null && IsInRange(interactor))
    {
      return interactText;
    }
    else { return interactTextOutOfRange; }
  }

  public abstract void OnInteract();

  public float GetRadius() { return radius; }

  public void Interact(GameObject interactor)
  {
    // check if in range
    if (!IsInRange(interactor))
    {
      Debug.Log("Out of range");
      return;
    }

    Debug.Log("Interacting with " + transform.name);
    OnInteract();
  }

  public bool IsInRange(GameObject interactor)
  {
    return Vector2.Distance(transform.position, interactor.transform.position) <= radius;
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, radius);
  }
}