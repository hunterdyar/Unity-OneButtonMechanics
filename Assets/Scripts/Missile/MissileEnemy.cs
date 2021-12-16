using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MissileEnemy : MonoBehaviour
{
	private ScoreManager _ScoreManager;
	public int pointsOnHit;
	public int pointsLostOnHitYou;
	private void Awake()
	{
		_ScoreManager = GameObject.FindObjectOfType<ScoreManager>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_ScoreManager.LosePoints(pointsLostOnHitYou);
		}
		else
		{
			//must be bullet
			//the only reason i am not making a bullet tag is so that it doesnt break when you copy it into a project with default tags.
			_ScoreManager.GetPoints(pointsOnHit);
		}
	}
}
