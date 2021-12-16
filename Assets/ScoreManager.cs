using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public int startingScore;

    void Start()
    {
        score = startingScore;
    }

    public int GetScore()
    {
        return score;
    }

    public void GetPoint()
    {
        GetPoints(1);
    }

    public void GetPoints(int points)
    {
        score += points;
    }

    public void LosePoints(int points)
    {
        score -= points;
        score = Mathf.Max(0, score);
    }
}
