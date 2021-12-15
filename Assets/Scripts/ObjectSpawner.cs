using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("To not randomize prefabs, simply only put one in the array.")]
    public GameObject[] prefabs;

    public void SpawnAtRandomLocationInRect(Rect area)
    {
        float x = Random.Range(area.xMin, area.xMax);
        float y = Random.Range(area.yMin, area.yMax);
        SpawnRandom(new Vector3(x, y, 0));
    }

    public void SpawnAtRandomLocationInRect(Vector2 boxMin, Vector2 boxMax)
    {
        float x = boxMin.x;
        float y = boxMin.y;
        //boxMin position, width, height.
        Rect rect = new Rect(boxMin,new Vector2(Mathf.Abs(boxMax.x-boxMin.x),Mathf.Abs(boxMax.y-boxMin.y)));
        SpawnAtRandomLocationInRect(rect);
    }

    public void SpawnAtRandomPositionBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        float r = Random.Range(0f, 1f);
        Vector3 randomLocation = Vector3.Lerp(a, b, r);
        SpawnRandom(randomLocation);
    }

    //This function has the same name as the above, but different properties.
    //this is called a method override. It lets us have multiple versions of the same object.
    public void SpawnAtRandomPositionBetweenTwoPoints(Transform a, Transform b)
    {
        SpawnAtRandomPositionBetweenTwoPoints(a.position,b.position);
    }

    //Spawns on the circle radius, not inside of it.
    public void SpawnAtRandomPositionOnCircle(Vector2 center, float radius)
    {
        Vector2 random = Random.insideUnitCircle;
        random.Normalize();//basically turns insideUnityCircle to OnUnitCircle.
        
        //we also could have passed in random angle values and used rotations, or trigonometry.
        
        //multiplied by radius, the vector will have a length of radius.
        Vector2 randomPoint = center + (Vector2)(random * radius);
        SpawnRandom(randomPoint);
    }
    public void SpawnAtRandomPositionInsideCircle(Vector2 center, float radius)
    {
        Vector2 random = Random.insideUnitCircle;//unit circle has radius of 1. This vector will have a maximum radius of 1.
        //multiplied by radius, the vector will have a length of radius.
        Vector2 randomPoint = center + (random * radius);
        SpawnRandom(randomPoint);
    }

    //todo: add a randomize rotation boolean flag.
    void SpawnRandom(Vector3 position)
    {
        //pick a random prefab
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)]; 
        
        //create it.
        Instantiate(prefab, position, quaternion.identity);
    }

    void SpawnRandom(Vector2 position)
    {
        //should we spawn at 0 position, our at OUR zero position?
        //should we offset given randomness by our position? (transform.positon plus....)
        //lots of options, just do what makes sense for your use case.
        SpawnRandom(new Vector3(position.x,position.y,0));
    }
}
