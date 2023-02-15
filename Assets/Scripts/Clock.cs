using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
  private TextMeshProUGUI text;

  private void Start()
  {
    text = GetComponent<TextMeshProUGUI>();
    TimeManager.OnMinuteChanged += GetTime;
  }
  private void GetTime()
  {
    text.SetText($"{TimeManager.Day:00}D | {TimeManager.Hour:00}:{TimeManager.Minute:00}");
  }
}