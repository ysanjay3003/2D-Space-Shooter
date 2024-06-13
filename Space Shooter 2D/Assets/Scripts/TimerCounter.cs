using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
	Text timeUI;    // Time Counter UI

	float startTime;    // time when play is pressed
	float elapsedTime;
	bool startCounter;

	float minutes;
	float seconds;
	// Use this for initialization
	void Start()
	{
		startCounter = false;
		timeUI = GetComponent<Text>();
	}

	// Start time countdown
	public void startTimeCounter()
	{
		startTime = Time.time;
		startCounter = true;
	}

	// Stop countdown
	public void stopTimeCounter()
	{
		startCounter = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (startCounter)
		{
			// Start counting time
			elapsedTime = Time.time - startTime;
			minutes = elapsedTime / 60;
			seconds = elapsedTime % 60;

			timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);    // update interface
		}
	}
}
