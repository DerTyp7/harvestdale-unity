using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{

  private static GuiManager instance;

  public static GuiManager Instance
  {
    get
    {
      if (instance == null)
      {
        instance = FindObjectOfType<GuiManager>();
        if (instance == null)
        {
          Debug.LogError("No GuiManager found in the scene.");
        }
      }
      return instance;
    }
  }



  [SerializeField] private List<GuiPanel> panels = new List<GuiPanel>();

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }


  public void RegisterPanel(GuiPanel panel)
  {
    panel.gameObject.SetActive(false);
    panels.Add(panel);
  }

  public GuiPanel GetPanelByName(string name)
  {
    name = name.ToLower();
    foreach (GuiPanel panel in panels)
    {
      if (panel.GetName().ToLower() == name)
      {
        return panel;
      }
    }
    return null;
  }

  public void OpenPanel(string name)
  {
    GuiPanel panel = GetPanelByName(name);
    if (panel != null)
    {
      OpenPanel(panel);
    }
  }

  public void OpenPanel(GuiPanel panel)
  {

    if (!panel.gameObject.activeSelf)
    {
      panel.gameObject.SetActive(true);
      panel.OnClose();
      Debug.Log("Open Panel");
      return;
    }
    Debug.Log("Panel is already opened");
  }


  public void ClosePanel(string name)
  {
    GuiPanel panel = GetPanelByName(name);
    if (panel != null)
    {
      ClosePanel(panel);
    }
  }

  public void ClosePanel(GuiPanel panel)
  {
    if (panel.gameObject.activeSelf)
    {
      panel.gameObject.SetActive(false);
      panel.OnClose();
      Debug.Log("Closed Panel");
      return;
    }
    Debug.Log("Panel is already closed");
  }


  public void CloseAllPanels()
  {
    foreach (GuiPanel panel in panels)
    {
      if (panel.gameObject.activeSelf)
      {
        ClosePanel(panel);
      }
    }
  }

  public void TogglePanel(string name)
  {
    GuiPanel panel = GetPanelByName(name);
    if (panel != null)
    {
      TogglePanel(panel);
    }
  }

  public void TogglePanel(GuiPanel panel)
  {
    if (panel != null)
    {
      if (panel.gameObject.activeSelf)
      {
        ClosePanel(panel);
      }
      else
      {
        OpenPanel(panel);
      }
    }
  }
}