using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectSpawner))]
public class ContinuousSpawner : MonoBehaviour
{
    
    [Header("Spawning Setup")] [Tooltip("How frequently to spawn items in seconds.")]
    [SerializeField]
    private float itemSpawnInterval;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [Range(0, 1)] [Tooltip("A percentage from 0 to 1, how much random variation to add to the spawn interval. Entering 0 will spawn consistently.")] [SerializeField]
    private float _spawnVariationPercentage;

    private float _timer;
    private float _timeToSpawnNext;
    
    private ObjectSpawner _spawner;
    
    void Awake()
    {
        //this is required so we dont have to null check
        _spawner = GetComponent<ObjectSpawner>();
        ResetTimer();
    }


    //Sets the timer back to 0 and resets the timetospawn next with new random variation
    void ResetTimer()
    {
        float varyAmount = itemSpawnInterval * _spawnVariationPercentage;
        float variation = Random.Range(-varyAmount, varyAmount);
        _timeToSpawnNext = itemSpawnInterval + variation;
        _timer = 0;
    }

    void Update()
    {
        _timer = _timer + Time.deltaTime;
        if (_timer >= _timeToSpawnNext)
        {
            _spawner.SpawnAtRandomPositionBetweenTwoPoints(pointA,pointB);
            ResetTimer();
        }
    }
}
