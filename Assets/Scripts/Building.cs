using UnityEngine;

public class Building : MonoBehaviour
{
  public bool isPlaced = false;
  public PlaceableObject placeableObject;

  public void Place()
  {
    isPlaced = true;
    BuildingManager.buildings.Add(this);
  }

  public void Demolish()
  {
    isPlaced = false;
    BuildingManager.buildings.Remove(this);
    Destroy(gameObject);
  }

  public Vector3Int GetGridPosition()
  {
    return new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
  }
}
