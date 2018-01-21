using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace util
{
  public class Alarm
  {
    private float previousAlarmTime;
    private float delay;

    public Alarm (float currentTime, float delay)
    {
      previousAlarmTime = currentTime;
      this.delay = delay;
    }

    // Returns if currentTime > previousAlarmTime + delay
    // Also resets currentTime when returning true.
    public bool CheckTimeUp (float currentTime)
    {
      if (currentTime > previousAlarmTime + delay) {
        currentTime = previousAlarmTime;
        return true;
      } else {
        return false;
      }
    }
  }
}