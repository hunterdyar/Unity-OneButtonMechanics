using System;
using UnityEngine;

public class MissileShooter : MonoBehaviour
{
	[SerializeField] private ScoreManager _scoreManager;
	[SerializeField] private GameObject missilePrefab;
	[SerializeField] private Transform fireLocation;
	[SerializeField] private float missileSpeed;
	[SerializeField] private float cooldownTime;
	private float _fireTimer;

	void Start()
	{
		_fireTimer = cooldownTime + 1;//pre-load the timer so we can shoot instantly. It's a small thing.
	}
	void Fire()
	{
		GameObject createdObject = Instantiate(missilePrefab, fireLocation.position, transform.rotation);
		Rigidbody2D missileRB = createdObject.GetComponent<Rigidbody2D>();
		missileRB.velocity = transform.up * missileSpeed;
	}

	private void Update()
	{
		_fireTimer += Time.deltaTime;
		//note that we are checking for GetButton, not GetButtonDown. You can hold it, and it will only shoot as fast as the cooldown timer.
		if (_fireTimer >= cooldownTime && Input.GetButton("Jump"))
		{
			Fire();
			_fireTimer = 0;
		}
	}
}
