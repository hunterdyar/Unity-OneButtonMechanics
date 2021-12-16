using UnityEngine;
using UnityEngine.Events;

public class ContinuousEventCall : MonoBehaviour
{

	[Header("Setup")] [Tooltip("How frequently to fire the event in seconds.")] [SerializeField]
	private float itemSpawnInterval;

	[Range(0, 1)] [Tooltip("A percentage from 0 to 1, how much random variation to add to the spawn interval. Entering 0 will spawn consistently.")] [SerializeField]
	private float _VariationPercentage;

	private float _timer;
	private float _timeToSpawnNext;

	public UnityEvent _event;

	void Awake()
	{
		ResetTimer();
	}


	//Sets the timer back to 0 and resets the timetospawn next with new random variation
	void ResetTimer()
	{
		float varyAmount = itemSpawnInterval * _VariationPercentage;
		float variation = Random.Range(-varyAmount, varyAmount);
		_timeToSpawnNext = itemSpawnInterval + variation;
		_timer = 0;
	}

	void Update()
	{
		_timer = _timer + Time.deltaTime;
		if (_timer >= _timeToSpawnNext)
		{
			_event.Invoke();
			ResetTimer();
		}
	}
}
