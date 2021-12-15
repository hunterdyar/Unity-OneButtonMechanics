using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class UIGameTimerText : MonoBehaviour
{
    public GameTimer gameTimer;
    //
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _text.text = gameTimer.GetPretty();
    }
}
