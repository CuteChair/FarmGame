using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    [Tooltip("How many seconds it takes for a minute to pass")]
    [SerializeField] private float SecondsToMinutes;
    private float gameSec;
    private int gameMin;
    private int gameHour;
    private int gameDay;

    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI dayTxt;
    [SerializeField] private TextMeshProUGUI dayStateTxt;

    private DayStateEnum currentDayState;
    private void Update()
    {
        gameSec += Time.deltaTime;

        CheckForMinutes();

        timeTxt.text = HourDisplay() + ":" + MinuteDisplay();
        dayTxt.text = gameDay.ToString();
        dayStateTxt.text = currentDayState.ToString();

        DayNightCycle();
    }

    private string MinuteDisplay()
    {
        if (gameMin < 10)
            return $"0{gameMin}";
        else
            return $"{gameMin}";
    }

    private string HourDisplay()
    {
        if (gameHour < 10)
            return $"0{gameHour}";
        else
            return $"{gameHour}";
    }
    private void CheckForMinutes()
    {
        if (gameSec >= SecondsToMinutes)
        {
            gameMin++;
            gameSec = 0;
            CheckForHours();
        }
    }

    private void CheckForHours()
    {
        if (gameMin == 60)
        {
            gameMin = 0;
            gameHour++;
            CheckForDay();
        }
    }
    private void CheckForDay()
    {
       if(gameHour == 24)
        {
            gameHour = 0;
            gameDay++;
        }
    }
    private void DayNightCycle()
    {
        switch (gameHour)
        {
            case 0:
                currentDayState = DayStateEnum.Night;
                break;
            case 6:
                currentDayState = DayStateEnum.Morning;
                break;
            case 11:
                currentDayState = DayStateEnum.Noon;
                break;
            case 13:
                currentDayState = DayStateEnum.AfterNoon;
                break;
            case 20:
                currentDayState = DayStateEnum.Night;
                break;
            default:
                break;
        }
    }

    public int GetHour()
    {
        return gameHour;
    }

    public float GetMin()
    {
        return gameMin;
    }
    
}

public enum DayStateEnum
{
    Morning,
    Noon,
    AfterNoon,
    Night

}
