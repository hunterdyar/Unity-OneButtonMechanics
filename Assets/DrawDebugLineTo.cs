using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDebugLineTo : MonoBehaviour
{
    public Transform other;

    private void OnGUI()
    {
        if (other != null)
        {
            Debug.DrawLine(transform.position, other.position);
        }
    }
}
