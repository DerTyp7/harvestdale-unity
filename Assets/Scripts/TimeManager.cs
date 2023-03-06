using UnityEngine;
using System;

public enum Season
{
  SPRING = 1,
  SUMMER = 2,
  AUTUMN = 3,
  WINTER = 4
}

public class TimeManager : MonoBehaviour
{
  public static Action OnMinuteChanged;
  public static Action OnHourChanged;
  public static Action OnDayChanged;
  public static Action OnMonthChanged;
  public static Action OnYearChanged;


  public static int Minute { get; private set; }
  public static int Hour { get; private set; }
  public static int Day { get; private set; }
  public static int Month { get; private set; }
  public static int Year { get; private set; }

  public static Season CurrentSeason => (Season)Month;

  [SerializeField]
  [Range(.05f, 10f)]
  private float minuteToRealTime = .05f;
  private float timer;

  private void Start()
  {
    Minute = 0;
    Hour = 10;
    Day = 25;
    Month = 4;
    Year = 1;
    timer = minuteToRealTime;
  }

  private void Update()
  {
    timer -= Time.deltaTime;

    if (timer <= 0)
    {
      // Increase minute
      Minute++;
      OnMinuteChanged?.Invoke();
      if (Minute >= 59)
      {
        // Increase hour
        Hour++;
        Minute = 0;
        if (Hour >= 24)
        {
          // Increase day
          Day++;
          Hour = 0;
          OnDayChanged?.Invoke();
          if (Day > 28)
          {
            // Increase month
            Month++;
            Day = 1;
            OnMonthChanged?.Invoke();
            if (Month > 4)
            {
              // Increase year
              Year++;
              Month = 1;
              OnYearChanged?.Invoke();
            }
          }
        }

        OnHourChanged?.Invoke();
      }

      timer = minuteToRealTime;
    }
  }
}