using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
public class BuildingManager : MonoBehaviour
{
  public static List<Building> buildings { get; private set; } = new List<Building>();

  public static Building GetBuildingByGridPosition(Vector3Int tilePosition)
  {
    foreach (Building building in buildings)
    {
      PlaceableObject po = building.placeableObject;
      Vector3Int buildingPosition = building.GetGridPosition();
      BoundsInt area = new BoundsInt(buildingPosition, po.GetSizeVector());
      if (area.Contains(tilePosition))
      {
        return building;
      }
    }

    return null;
  }
}