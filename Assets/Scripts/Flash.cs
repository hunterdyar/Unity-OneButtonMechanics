using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Light light;

    private float _brightness;
    // Start is called before the first frame update

    private void Awake()
    {
        light = GetComponentInChildren<Light>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        _brightness = 15;
        light.intensity =  _brightness;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _brightness = 5.75f;
        light.intensity = _brightness;
    }
    
}
