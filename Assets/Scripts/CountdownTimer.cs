﻿
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//This class and GameTimer are copied and pasted from each other to start.
//thats terrible!
//Creating a base class with the timer object, the pause/unpause, and the GetPretty stuff in it would be excellent
public class CountdownTimer : MonoBehaviour
{

	private float _timer;
	public float totalTime;
	public bool BeginOnAwake;
	private bool active = false;

	public UnityEvent OnTimerFinishedEvent;
	private void Awake()
	{
		active = false;
		if (BeginOnAwake)
		{
			BeginTimer();
		}
	}

	void BeginTimer()
	{
		_timer = totalTime;
		active = true;
	}

	private void Update()
	{
		_timer = _timer - Time.deltaTime;
	}

	private void TimerFinished()
	{
		OnTimerFinishedEvent.Invoke();
	}

	public int GetSeconds()
	{
		//We do ceil instead of floor because its a countDOWN timer.
		//We dont want to display "0" on the clock if there is 0.3 seconds left.
		return Mathf.CeilToInt(_timer % 60f);
	}
	TimeSpan GetAsTimeSpan()
	{
		int minutes = Mathf.FloorToInt(_timer / 60f);
		int seconds = GetSeconds();
		int milli = Mathf.RoundToInt((_timer - minutes * 60 - seconds) * 100);
		TimeSpan ts = new TimeSpan(0, minutes, seconds, milli);
		return ts;
	}
}
