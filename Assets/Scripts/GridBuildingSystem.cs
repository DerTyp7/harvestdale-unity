using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
  public PlaceableObject placeableObject;


  public Tilemap collisionTm;

  GameObject newBuilding;


  private void Start()
  {
    newBuilding = Instantiate(placeableObject.prefab, Vector3.zero, Quaternion.identity);
  }
  private void Update()
  {
    if (newBuilding)
    {
      Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //* Cursor.visible = false;
      int snappedX = Mathf.RoundToInt(newPosition.x);
      int snappedY = Mathf.RoundToInt(newPosition.y);
      Vector3Int snappedPosition = new Vector3Int(snappedX, snappedY, 0);

      newBuilding.transform.position = snappedPosition;

      // TODO change to red if occupied

      if (Input.GetMouseButtonDown(0) && !IsOccupied(snappedPosition, placeableObject))
      {
        placeableObject.Place();
        // TODO mark tiles as occupied
        // TODO unselect
      }
    }

  }

  private bool IsOccupied(Vector3Int startPos, PlaceableObject po)
  {
    Vector3Int poSize = new Vector3Int(po.width, po.height, 1);

    BoundsInt area = new BoundsInt(startPos, poSize);
    TileBase[] tileArray = collisionTm.GetTilesBlock(area);

    foreach (TileBase tile in tileArray)
    {
      if (tile != null)
      {
        return true;
      }
    }

    return false;
  }
}
