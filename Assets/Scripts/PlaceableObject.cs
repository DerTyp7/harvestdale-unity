using UnityEngine;

[CreateAssetMenu(fileName = "New PlacableObject", menuName = "Harvestdale/PlaceableObjects", order = 0)]
public class PlaceableObject : ScriptableObject
{
  public string objectName;
  //   public Sprite icon;
  public GameObject prefab;
  public int width;
  public int height;

  public void Place()
  {
    Debug.Log("PLACE");
  }
}