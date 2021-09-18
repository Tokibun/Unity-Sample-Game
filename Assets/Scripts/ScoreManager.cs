using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int playerScore = 0;
	//Singleton reference
	//This has a public getter, but a private setter
	public static ScoreManager ScoreManagerInstance{get;private set;}
	//Awake is called before start, and this is called once.
	//Allows for others to get this ScoreManager instance

	public UpdatePlayerInfo UpdatePlayerInfo;
	
	public void Awake()
	{
		ScoreManagerInstance = this;
	}

	public void Start()
	{
		UpdatePlayerInfo = GameObject.FindObjectOfType<UpdatePlayerInfo>();
		UpdatePlayerInfo.UpdateScoreText(playerScore);
	}


	public void UpdateScore()
    {
	    playerScore += 1;
	    UpdatePlayerInfo.UpdateScoreText(playerScore);
    }
}
