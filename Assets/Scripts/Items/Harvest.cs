using UnityEngine;

[CreateAssetMenu(fileName = "Harvest", menuName = "Harvestdale/Items/Harvest", order = 0)]
public class Harvest : Item
{
  [SerializeField]
  private int price;

  public int Price
  {
    get { return price; }
  }

}