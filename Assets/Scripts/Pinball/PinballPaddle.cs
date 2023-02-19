using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPaddle : MonoBehaviour
{

    [SerializeField] private float pushForce;
    [SerializeField] private float returnForce;
    [SerializeField] private float forceTime = 0.1f;
    private bool reverse;
    //google "Ternary Operator"
    
    private HingeJoint2D _hinge;

    private Coroutine flipRoutine;
    // Start is called before the first frame update
    private void Awake()
    {
        _hinge = GetComponent<HingeJoint2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        _hinge.connectedBody.AddForce(Vector3.down*returnForce);
    }

    private void Flip()
    {
        if (flipRoutine != null)
        {
            StopCoroutine(flipRoutine);
        }

        flipRoutine = StartCoroutine(DoFlip());
    }

    IEnumerator DoFlip()
    {
        _hinge.useMotor = true;
        var paddleMotor = new JointMotor2D();
        paddleMotor.motorSpeed = pushForce;
        paddleMotor.maxMotorTorque = 1000000;
        _hinge.motor = paddleMotor;
        
        yield return new WaitForSeconds(forceTime);
        while (Input.GetButton("Jump"))
        {
            yield return null;
        }

        _hinge.useMotor = false;
    }
}
