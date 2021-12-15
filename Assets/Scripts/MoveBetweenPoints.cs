using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

//This script will oscillate an object between two points (defined as transforms). 
//It does not use a coroutine (which is preferred)
public class MoveBetweenPoints : MonoBehaviour
{
    //Configuration
    [Header("Configuration")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve easingCurve;
    
    //Internal things
    private Transform _start;
    private Transform _goal;

    private float timer;
    private float timeToMove;

    //UnityEvents
    //public so other scripts can add listeners themselves.
    public UnityEvent AtPointEvent;
    void Start()
    {
        SetupStartToGoal(pointA,pointB);
        transform.position = _start.position;
    }
    void SetupStartToGoal(Transform start, Transform goal)
    {
        _start = start;
        _goal = goal;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Recalculate distance and movement speed every frame.
        //We could do this just once in SetupStartToGoal
        //Doing it every frame lets us move the positions and change the speed every count.
        float distance = Vector3.Distance(_start.position, _goal.position);
        timeToMove = distance / movementSpeed;
        
        //
        timer = timer + Time.deltaTime/timeToMove;
        transform.position = Vector3.Lerp(_start.position, _goal.position, easingCurve.Evaluate(timer));
        if (timer >= 1)
        {
            //we are (not exactly, but within a frame of movement) at the goal.
            //if the goal is position a, we are at a, lets reset to move a to b.
            if (pointA == _goal)
            {
                SetupStartToGoal(pointA,pointB);
            }else if (pointB == _goal)//if the point b is the goal (and where we should currently b)
            {
                SetupStartToGoal(pointB,pointA);//then move from b back to a.
            }
            else
            {
                Debug.LogError("Something has gone wrong? Did a goal point get deleted?");
            }

            AtPosition();
        }
    }

    private void AtPosition()
    {   
        AtPointEvent.Invoke();
    }

    public void SetSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
