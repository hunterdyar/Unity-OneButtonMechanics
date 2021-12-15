using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some useful functions (well only one right now) to move a rigidbody-owning shape around on the screen.
public class RigidMovement : MonoBehaviour
{
	private Collider2D _collider2D;
	private Rigidbody2D _rigidbody2D;
	public bool UseConstantVelocity;
	public Vector2 constantVel;
	
	private void Awake()
	{
		_collider2D = GetComponent<Collider2D>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		//
		if (_collider2D == null)
		{
			Debug.LogError("No collider for collidermovement",this);
		}
		
		if (_rigidbody2D == null)
		{
			Debug.LogError("RigidMovement needs a rigidbody. The rigidbody can be set to static.",this);
		}
	}

	void Start()
	{
		if (UseConstantVelocity)
		{
			SetConstantVelocity(constantVel);
		}
	}
	//Sets our velocity to the velocity, but also turns off the dumb stuff we usually forget about.
	public void SetConstantVelocity(Vector2 velocity)
	{
		_rigidbody2D.drag = 0;
		_rigidbody2D.gravityScale = 0;
		_rigidbody2D.velocity = velocity;
	}
	
	public bool MoveAsFarAsPossibleInOneDirection(Vector2 direction)
	{
		RaycastHit2D[] results = new RaycastHit2D[5];
		int castCount = _collider2D.Cast(direction, results,Mathf.Infinity);
		if (castCount == 0)
		{
			//we can move... infinitely far? 
			//no good.
			return false;
		}
		else
		{
			//position plus (direction times distance) 
			transform.position += (Vector3)direction.normalized*results[0].distance;
			return true;
		}
	}
	
	//
}
