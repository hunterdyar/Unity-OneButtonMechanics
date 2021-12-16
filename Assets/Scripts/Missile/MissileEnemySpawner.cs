using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemySpawner : MonoBehaviour
{
    private ObjectSpawner _spawner;
    [SerializeField] private Transform target;
    [SerializeField] private float _enemyRadius;
    
    //Called by ContinuousEventCall
    private void Awake()
    {
	    _spawner = GetComponent<ObjectSpawner>();
    }

    public void SpawnEnemy()
    {
	    GameObject spawned = _spawner.SpawnAtRandomPositionOnCircle(transform.position,_enemyRadius);
	    spawned.GetComponent<ChaseTarget>().SetTarget(target);
    }
    
}
