using UnityEngine;

[CreateAssetMenu(fileName = "Hoe", menuName = "Harvestdale/Tools/Hoe", order = 0)]
public class Hoe : Tool
{
  public override void OnUse()
  {
    throw new System.NotImplementedException();
  }

  public override void Use()
  {
    OnUse();
  }
}