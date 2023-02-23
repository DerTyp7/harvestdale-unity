using UnityEngine;


public abstract class Tool : Item
{
  public abstract void Use();
  public abstract void OnUse();

  private void Awake()
  {
    stackable = false;
    maxStackSize = 1;
  }
}