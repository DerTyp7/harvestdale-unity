using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{

  public PlaceableObject TESTPO; //! DEBUG
  public Tilemap collisionTm;
  public TileBase occupiedTile;

  private PlaceableObject placeableObject;
  private GameObject newBuildingObject;
  private bool isDemolishing = false;

  private void Update()
  {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    int snappedX = Mathf.RoundToInt(mousePosition.x);
    int snappedY = Mathf.RoundToInt(mousePosition.y);
    Vector3Int snappedMousePosition = new Vector3Int(snappedX, snappedY, 0);

    if (Input.GetKeyDown(KeyCode.N))
    {
      isDemolishing = !isDemolishing;
      Debug.Log(isDemolishing);
    }

    if (!isDemolishing)
    {
      //! DEBUG
      if (Input.GetKeyDown(KeyCode.B))
      {
        SelectBuilding(TESTPO);
      }

      if (Input.GetMouseButtonDown(1))
      {
        UnselectBuilding();
      }

      if (newBuildingObject)
      {
        Cursor.visible = false;

        newBuildingObject.transform.position = snappedMousePosition;
        bool isOccupied = IsOccupied(snappedMousePosition, placeableObject.GetSizeVector());

        if (isOccupied)
        {
          newBuildingObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
          newBuildingObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetMouseButtonDown(0) && !isOccupied)
        {
          newBuildingObject.GetComponent<Building>().Place();
          newBuildingObject.GetComponent<Building>().placeableObject = placeableObject;
          OccupyTiles(snappedMousePosition, placeableObject.GetSizeVector());
          newBuildingObject = null;
        }
      }
      else
      {
        Cursor.visible = true;
      }
    }
    else
    {
      if (Input.GetMouseButtonDown(0))
      {
        Building demoBuilding = BuildingManager.GetBuildingByGridPosition(snappedMousePosition);

        if (demoBuilding)
        {
          demoBuilding.Demolish();
          UnOccupyTiles(demoBuilding.GetGridPosition(), demoBuilding.placeableObject.GetSizeVector());
        }
      }
    }

  }

  public void SelectBuilding(PlaceableObject newPo)
  {
    if (newBuildingObject)
    {
      Destroy(newBuildingObject);
    }

    placeableObject = newPo;
    newBuildingObject = Instantiate(placeableObject.prefab, Vector3.zero, Quaternion.identity);
  }

  public void UnselectBuilding()
  {
    if (newBuildingObject)
    {
      Destroy(newBuildingObject);
    }
    newBuildingObject = null;
    placeableObject = null;
  }

  private void OccupyTiles(Vector3Int startPos, Vector3Int poSize)
  {
    BoundsInt area = new BoundsInt(startPos, poSize);
    TileBase[] tileArray = new TileBase[area.size.x * area.size.y * area.size.z];
    for (int index = 0; index < tileArray.Length; index++)
    {
      tileArray[index] = occupiedTile;
    }

    collisionTm.SetTilesBlock(area, tileArray);

  }

  private void UnOccupyTiles(Vector3Int startPos, Vector3Int poSize)
  {
    BoundsInt area = new BoundsInt(startPos, poSize);
    TileBase[] tileArray = new TileBase[area.size.x * area.size.y * area.size.z];
    for (int index = 0; index < tileArray.Length; index++)
    {
      tileArray[index] = null;
    }

    collisionTm.SetTilesBlock(area, tileArray);
  }

  private bool IsOccupied(Vector3Int startPos, Vector3Int poSize)
  {


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
