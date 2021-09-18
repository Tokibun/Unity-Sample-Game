using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerInfo : MonoBehaviour
{
    public GameObject playerScoreObj;
    private GameObject playerLivesObj;
    public GameObject GameOverText;
    
    private Text playerScoreText;
    private Text playerLivesText;

    public SpawnChar SpawnChar;
    
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        
        playerScoreText = playerScoreObj.GetComponent<Text>();

        SpawnChar = GameObject.FindObjectOfType<SpawnChar>();
        playerLivesObj = GameObject.Find("Lives");
        playerLivesText = playerLivesObj.GetComponent<Text>();
        playerLivesText.text = "Num of Lives " + SpawnChar.NumOfLives;

    }

    public void UpdateScoreText(int score)
    {
        playerScoreText.text = "Score: " + score;
    }

    public void UpdatePlayerLivesText(int lives)
    {
        playerLivesText.text = "Num of Lives " + lives;
    }

    public void DisplayGameOver()
    {
        GameOverText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
