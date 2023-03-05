using UnityEngine;

public class FarmManager : MonoBehaviour
{

  // Singleton
  public static FarmManager Instance { get; private set; }

  [SerializeField]
  private Inventory<Crop> cropInventory;

  [SerializeField]
  private Inventory<Harvest> harvestInventory;

  public Inventory<Crop> CropInventory
  {
    get { return cropInventory; }
  }

  public Inventory<Harvest> HarvestInventory
  {
    get { return harvestInventory; }
  }

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }
  private void Start()
  {
    cropInventory = new Inventory<Crop>(2, 200);
    harvestInventory = new Inventory<Harvest>(2, 200);
  }
}