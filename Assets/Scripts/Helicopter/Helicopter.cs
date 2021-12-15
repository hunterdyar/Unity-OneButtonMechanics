using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameTimer))]
public class Helicopter : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private GameTimer _gameTimer;
    [SerializeField] private float force;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameTimer = GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up*force);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.LogError("Game Over");
        _gameTimer.Pause();
    }
}
