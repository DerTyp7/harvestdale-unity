using UnityEngine;

[CreateAssetMenu(fileName = "Hoe", menuName = "Harvestdale/Tools/Hoe", order = 0)]
public class Hoe : Tool
{
  public override void OnUse()
  {
    Debug.Log("Hoe on use");

  }

  public override void Use()
  {
    Debug.Log("Hoe use");
    OnUse();
  }
}