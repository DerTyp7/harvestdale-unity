using UnityEngine;

public abstract class Building : MonoBehaviour
{
  public bool isPlaced = false;
  public PlaceableObject placeableObject;

  public abstract void OnPlace();
  public void Place()
  {
    isPlaced = true;
    BuildingManager.buildings.Add(this);
    OnPlace();
  }

  public void Demolish()
  {
    isPlaced = false;
    BuildingManager.buildings.Remove(this);
    Destroy(gameObject);
  }

  public Vector3Int GetGridPosition()
  {
    return new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
  }
}
