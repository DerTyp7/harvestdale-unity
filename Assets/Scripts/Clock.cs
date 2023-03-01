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
    text.SetText($"{TimeManager.Hour:00}:{TimeManager.Minute:00}<br>{TimeManager.Day:00}.{TimeManager.Month:00}.{TimeManager.Year:00}");
  }
}