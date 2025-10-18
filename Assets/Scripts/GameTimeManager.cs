using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    private float gameTime;

    private int gameDay;

    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI dayTxt;
    [SerializeField] private TextMeshProUGUI dayStateTxt;

    private DayStateEnum currentDayState;
    private void Update()
    {
        gameTime += Time.deltaTime;

        timeTxt.text = gameTime.ToString();

        DayNightCycle();
    }

    private void DayNightCycle()
    {
        if (gameTime >= 7 && gameTime < 11)
        {
            currentDayState = DayStateEnum.Morning;
        }
        else if (currentDayState != DayStateEnum.Noon && gameTime >= 11 && gameTime <= 13)
        {
            currentDayState = DayStateEnum.Noon;
        }
        else if (currentDayState != DayStateEnum.AfterNoon && gameTime > 13 && gameTime <= 19)
        {
            currentDayState = DayStateEnum.AfterNoon;
        }
        else if (currentDayState != DayStateEnum.Night && gameTime > 19)
        {
            currentDayState = DayStateEnum.Night;  
        }

        dayStateTxt.text = currentDayState.ToString();
        if (gameTime >= 24)
        {
            SetDay();
        }
    }
    private void SetDay()
    {
        gameTime = 0f;
        gameDay++;
        dayTxt.text = gameDay.ToString();
        print("Current Day : " + gameDay);
    }

    
}

public enum DayStateEnum
{
    Morning,
    Noon,
    AfterNoon,
    Night

}
