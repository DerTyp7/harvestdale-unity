using UnityEngine;

public abstract class GuiPanel : MonoBehaviour
{
  [SerializeField] private string panelName;

  public string GetName()
  {
    return panelName;
  }

  private void Awake()
  {
    GuiManager.Instance.RegisterPanel(this);
  }

  public abstract void OnOpen();
  public abstract void OnClose();
}



