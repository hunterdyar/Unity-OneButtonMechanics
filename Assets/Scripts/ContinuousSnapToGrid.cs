using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousSnapToGrid : MonoBehaviour
{
    public Transform goalPosition;
    //we assume world space, and world-position 0,0 as origin of the grid.
    public float gridScale = 1;

    void Update()
    {
        SnapTo(goalPosition.position);
    }

    //We update the world position instead of local position. 
    //This has the advantage of letting us keep the object as a child of the parent, as it basically ignores the parent position and just moves to goalPosition
    //but! Can set goal to the parent position, and now a snappy child exists.
    public void SnapTo(Vector3 position)
    {
        //multiply position by scale, round to nearest integer, then divide by scale.
        position = position * gridScale;
        position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
        position = position / gridScale;
        transform.position = position;
    }
}
