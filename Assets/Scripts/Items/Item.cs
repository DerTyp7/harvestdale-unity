using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Harvestdale/Items/Item", order = 0)]
public class Item : ScriptableObject
{
  [SerializeField]
  private string uuid;

  [SerializeField]
  private string itemName;

  [SerializeField]
  private Sprite icon;


  public string UUID
  {
    get { return uuid; }
  }

  public string ItemName
  {
    get { return itemName; }
  }

  public Sprite Icon
  {
    get { return icon; }
  }
}