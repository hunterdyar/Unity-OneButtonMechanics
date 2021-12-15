using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float timer;
    public bool active = true;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (active)
        {
            timer = timer + Time.deltaTime;
        }
    }

    public float GetTime()
    {
        return timer;
    }

    public void Pause()
    {
        active = false;
    }

    public void Resume()
    {
        active = true;
    }

    public void TogglePlayPause()
    {
        active = !active;
    }

    public void Restart()
    {
        timer = 0;
    }

    public string GetPretty()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);//Modulo! google it.
        int milli = Mathf.RoundToInt((timer - minutes * 60 - seconds) * 100);
        
        
        //Making the numbers a  pretty string is hard. C# can do it for me.
        //https://docs.microsoft.com/en-us/dotnet/api/system.timespan
        TimeSpan ts = new TimeSpan(0,minutes,seconds,milli);
        return ts.ToString();
    }
}
