// Interactable object which lets the player plant & harvest a seed
using UnityEngine;

public class FieldController : Interactable
{
  public Field field;
  public Crop testCrop;

  public override void OnInteract()
  {
    Debug.Log("Interacting with field");
    field.Plant(testCrop);
  }
}