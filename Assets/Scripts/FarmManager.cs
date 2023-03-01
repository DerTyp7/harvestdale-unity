using UnityEngine;

public class FarmManager : MonoBehaviour
{
  public Inventory<Crop> cropInventory;
  private void Start()
  {
    cropInventory = new Inventory<Crop>(2, 200);
  }
}