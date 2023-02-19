using System;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameStateController _gameState;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _gameState.GameOver();
    }
}
