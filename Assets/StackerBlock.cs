using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackerBlock : MonoBehaviour
{
    private RigidMovement _movement;
    [SerializeField] private float goalThresholdYPosition;
    void Start()
    {
        _movement = GetComponent<RigidMovement>();
        bool didMove = _movement.MoveAsFarAsPossibleInOneDirection(Vector2.down);
        if (!didMove)
        {
            //report errors.
            Debug.LogError("Unable to snap downwards. ",gameObject);
        }
        
        //
        if (transform.position.y >= goalThresholdYPosition)
        {
            Debug.Log("You Win");
        }
    }
}
