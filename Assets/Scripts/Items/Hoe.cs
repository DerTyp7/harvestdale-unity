using UnityEngine;

[CreateAssetMenu(fileName = "Hoe", menuName = "Harvestdale/Tools/Hoe", order = 0)]
public class Hoe : Tool
{

  GameObject player;
  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  private Vector3 GetVector3IntInMouseDirection()
  {

    Vector3 direction = (player.transform.position - GridBuildingSystem.Instance.GetSnappedMousePosition()).normalized;
    Debug.Log(direction);
    return direction;
  }
  public override void OnUse()
  {
    Debug.Log("Hoe on use");
    GetVector3IntInMouseDirection();

  }

  public override void Use()
  {
    Debug.Log("Hoe use");
    OnUse();
  }
}