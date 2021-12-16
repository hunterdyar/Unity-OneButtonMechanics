using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBPM : MonoBehaviour
{
    private TMP_Text _text;
    public BPMGuesser bpmGuesser;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = bpmGuesser.userBPM.ToString();
    }
}
