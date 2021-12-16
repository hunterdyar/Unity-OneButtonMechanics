using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private SpinDirection _direction;

    [SerializeField] private float _spinSpeed;
    //
    public enum SpinDirection
    {
        Clockwise,
        CounterClockwise
    }

    // Update is called once per frame
    void Update()
    {
        int dir = 1;
        if (_direction == SpinDirection.CounterClockwise)
        {
            dir = -1;
        }
        
        //axis-angle rotation
        //Vector3.back is 0,0,-1 AKA towards the camera.
        transform.Rotate(Vector3.back,_spinSpeed*dir*Time.deltaTime);
    }
}
