using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Crop", menuName = "Harvestdale/Items/Crop", order = 0)]
public class Crop : Item
{
  [SerializeField]
  private List<Sprite> sprites = new List<Sprite>();

  [SerializeField]
  private Harvest harvestItem;

  [SerializeField]
  private Season seasonToPlant;

  [SerializeField]
  private Season seasonToHarvest;

  public List<Sprite> Sprites
  {
    get { return sprites; }
  }

  public Harvest HarvestItem
  {
    get { return harvestItem; }
  }

  public Season SeasonToPlant
  {
    get { return seasonToPlant; }
  }

  public Season SeasonToHarvest
  {
    get { return seasonToHarvest; }
  }
}