using System;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class ChaseTarget : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float movementSpeed;

	public bool chaseActive;
	public bool faceTarget;

	//
	private bool atTarget;
	private Rigidbody2D _rigidbody2D;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Vector3 targetDirection = target.position - transform.position;
		atTarget = targetDirection.magnitude < 0.1f;
		if (!atTarget)
		{
			targetDirection.Normalize(); //magnitude of 1
			_rigidbody2D.velocity = targetDirection * movementSpeed;
		}
		else
		{
			//made it to target
			_rigidbody2D.velocity = Vector2.zero;
		}

		if (faceTarget)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
		}
	}

	public bool IsAtTarget()
	{
		return atTarget;
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
