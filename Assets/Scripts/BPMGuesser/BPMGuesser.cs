using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BPMGuesser : MonoBehaviour
{
	private List<float> userBeats;
	private float previousBeatTime = 0;
	public float userBPM;
	public bool active;
	public int randomBPM;
	
	void Start()
	{
		active = true;
		userBeats = new List<float>();
		randomBPM = GetRandomBPM();
	}

	public int GetRandomBPM()
	{
		return Random.Range(6, 30)*10;
	}
    // Update is called once per frame
    void Update()
    {
	    if (active && Input.GetButtonDown("Jump"))
	    {
		    UserBeat();
	    }   
    }
    void UserBeat()
    {
	    //dont start until after the first press
	    if (previousBeatTime != 0)
	    {
		    float timeDifference = Time.time - previousBeatTime;
		    userBeats.Add(timeDifference);
		    userBPM = UserBPM();
	    }
	    previousBeatTime = Time.time;
    }

    float AverageTime()
    {
	    return userBeats.Average();//this useful function is in the LINQ class. LINQ is great.
    }

    public float UserBPM()
    {
	    return Mathf.Round(((60/AverageTime())));
    }

    public float GetScore()
    {
	    //How should score actually be calculated? I think in the amount of seconds off from the correct, where 0 is perfect?
	    float desiredAverageTimeDifference = 1/(randomBPM / 60f);
	    float score = Mathf.Abs(desiredAverageTimeDifference - AverageTime());
	    //
	    //rounding to specific place with multiply/divide trick
	    score = score * 1000;
	    score = Mathf.Round(score) / 10;
//
	    return score;
    }
}
