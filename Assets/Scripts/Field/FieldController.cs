// Interactable object which lets the player plant & harvest a seed
using UnityEngine;

public class FieldController : Interactable
{
  private Field field;

  public override string interactText => field.State == FieldState.EMPTY ? "Plant" : field.State == FieldState.HARVESTABLE ? "Harvest" : field.State == FieldState.GROWING && !field.IsWatered ? "Water" : "Empty";

  public void SetField(Field field)
  {
    this.field = field;
  }

  public override void OnInteract()
  {
    Debug.Log("Interacting with field");
    if (field.State == FieldState.EMPTY)
    {
      if (FarmManager.Instance.CropInventory.Items.Length > 0)
        field.Plant(FarmManager.Instance.CropInventory.Items[0].item);
    }
    else if (field.State == FieldState.HARVESTABLE)
    {
      field.Harvest();
    }
    else if (field.State == FieldState.GROWING && !field.IsWatered)
    {
      field.Water();
    }
    else
    {
      field.EmptyField();
    }

  }
}