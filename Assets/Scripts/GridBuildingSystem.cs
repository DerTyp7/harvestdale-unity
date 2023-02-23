using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{

  private static GridBuildingSystem instance;

  public static GridBuildingSystem Instance
  {
    get
    {
      if (instance == null)
      {
        instance = FindObjectOfType<GridBuildingSystem>();
        if (instance == null)
        {
          Debug.LogError("No GridBuildingSystem found in the scene.");
        }
      }
      return instance;
    }
  }
  public PlaceableObject TESTPO; //! DEBUG

  public Tilemap collisionTm;
  public Tilemap occupiedTm;
  public TileBase occupiedTile;

  private PlaceableObject placeableObject;
  private GameObject newBuildingObject;
  private bool isDemolishing = false;

  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
      return;
    }
    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  private void Update()
  {
    Vector3Int snappedMousePosition = GetSnappedMousePosition();

    if (Input.GetKeyDown(KeyCode.N))
    {
      UnselectBuilding();
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
      Cursor.visible = true;
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
  public Vector3Int GetSnappedMousePosition()
  {
    return GetSnappedPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
  }

  public Vector3Int GetSnappedPosition(Vector3 pos)
  {
    int snappedX = Mathf.FloorToInt(pos.x);
    int snappedY = Mathf.FloorToInt(pos.y);
    return new Vector3Int(snappedX, snappedY, 0);
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

    occupiedTm.SetTilesBlock(area, tileArray);

  }

  private void UnOccupyTiles(Vector3Int startPos, Vector3Int poSize)
  {
    BoundsInt area = new BoundsInt(startPos, poSize);
    TileBase[] tileArray = new TileBase[area.size.x * area.size.y * area.size.z];
    for (int index = 0; index < tileArray.Length; index++)
    {
      tileArray[index] = null;
    }

    occupiedTm.SetTilesBlock(area, tileArray);
  }

  private bool IsOccupied(Vector3Int startPos, Vector3Int poSize)
  {
    BoundsInt area = new BoundsInt(startPos, poSize);
    List<TileBase> tileArray = new List<TileBase>(occupiedTm.GetTilesBlock(area));
    tileArray.AddRange(collisionTm.GetTilesBlock(area));
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
