using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BPMGuesser : MonoBehaviour
{
	private List<float> userBeats;
	private float previousBeatTime = 0;
	public float userBPM;
	public bool active;
	void Start()
	{
		userBeats = new List<float>();
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
}
