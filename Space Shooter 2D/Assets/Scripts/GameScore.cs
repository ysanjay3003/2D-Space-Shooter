using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
	Text scoreText;    // put UI Staff
	int userScore;

	public int Score
	{
		get
		{
			return this.userScore;
		}
		set
		{
			this.userScore = value;
			UpdateScoreTextUI();
		}
	}

	// Use this for initialization
	void Start()
	{
		// Get Text UI Component of this gameobject 
		scoreText = GetComponent<Text>();
	}

	// update score
	public void UpdateScoreTextUI()
	{
		string scoreString = string.Format("{0:000000}", userScore);
		scoreText.text = scoreString;
	}
}
