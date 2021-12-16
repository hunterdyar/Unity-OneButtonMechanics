using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBPMTextSetter : MonoBehaviour
{
    public TMP_Text gameplayText;

    public TMP_Text gameOverText;

    public BPMGuesser Guesser;

    void Start()
    {
        gameplayText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }
    public void OnGameplayStart()
    {
        gameplayText.gameObject.SetActive(true);
        gameplayText.text = "Try To Tap At " + Guesser.randomBPM;
    }

    public void OnGameOver()
    {
        gameplayText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        

        gameOverText.text = "Attempted " + Guesser.randomBPM + "<br> Actually Tapped At: " + Guesser.userBPM+"<br> Error: "+Guesser.GetScore()+". Lower is better. <br> Press R to Restart.";
    }
}
