using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class TimeManager : MonoBehaviour
{
  public static Action OnMinuteChanged;
  public static Action OnHourChanged;
  public static Action OnDayChanged;

  public static int Minute { get; private set; }
  public static int Hour { get; private set; }
  public static int Day { get; private set; }

  private float minuteToRealTime = .5f;
  private float timer;

  private void Start()
  {
    Minute = 0;
    Hour = 10;
    Day = 1;
    timer = minuteToRealTime;
  }

  private void Update()
  {
    timer -= Time.deltaTime;

    if (timer <= 0)
    {
      Minute++;
      OnMinuteChanged?.Invoke();
      if (Minute >= 60)
      {
        Hour++;
        Minute = 0;
        if (Hour >= 24)
        {
          Day++;
          Hour = 0;
          OnDayChanged?.Invoke();
        }

        OnHourChanged?.Invoke();
      }

      timer = minuteToRealTime;
    }
  }
}