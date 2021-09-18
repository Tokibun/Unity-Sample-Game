using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    private GameObject _playerChar;
    private Transform _playerTransform;
    private Vector3 _charSpawnLocation = new Vector3(0f, 1.4f, -1f);
    private Rigidbody _rigidbody;

    private const float _respawnheight = -5f;

	
	public const int NumOfLives = 3;
	public int PlayerLivesLeft;

	public bool GameEnded = false;
	
	public UpdatePlayerInfo UpdatePlayerInfo;

    // Start is called before the first frame update
    private void Start()
    {
        _playerChar = GameObject.Instantiate(Resources.Load("Character"), _charSpawnLocation, Quaternion.identity) as GameObject;
        _playerTransform = _playerChar.transform;
        _rigidbody = _playerChar.GetComponent<Rigidbody>();

		PlayerLivesLeft = NumOfLives;
		
		UpdatePlayerInfo = GameObject.FindObjectOfType<UpdatePlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerTransform.position.y < _respawnheight)
        {
			if (PlayerLivesLeft > 0)
			{
            	//Moving the player back to the spawn location
            	_playerTransform.position = _charSpawnLocation;
            	_rigidbody.velocity = new Vector3(0, 0, 0);
            	//Reset the rotation
            	_playerTransform.rotation = Quaternion.Euler( new Vector3(0,0,0));   
				PlayerLivesLeft-=1; 
				UpdatePlayerInfo.UpdatePlayerLivesText(PlayerLivesLeft);
			}
			else
			{
				EndGame();
				UpdatePlayerInfo.DisplayGameOver();
			}
        }
    }

    private void EndGame()
    {
	    GameEnded = true;
	    Time.timeScale = 0;
	    
    }
}
