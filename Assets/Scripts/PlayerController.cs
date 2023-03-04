using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

  [SerializeField]
  LayerMask interactableLayer; // Layermask for interactable objects



  // Update is called once per frame
  void Update()
  {
    // Interactable
    if (Input.GetKeyDown(KeyCode.E))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D hit;

      hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, interactableLayer);

      if (hit.collider != null)
      {
        Interactable interactable = hit.collider.GetComponent<Interactable>();
        if (interactable != null)
        {
          interactable.Interact(gameObject);
        }
      }
    }
  }
}
