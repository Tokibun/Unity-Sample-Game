using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    //The problem with the previous solution being unable to obtain the ScoreManager reference
    //Is probably due to a race condition. The coins must've been created before the score
    //manager is created, therefore unable to find the score manager when it was created.
    //public ScoreManager ScoreManager;
    
    private void start()
    {
        //The problem with the previous solution being unable to obtain the ScoreManager reference
        //Is probably due to a race condition. The coins must've been created before the score
        //manager is created, therefore unable to find the score manager when it was created.
        //ScoreManager = FindObjectOfType<ScoreManager>();
        
    }
    private void OnCollisionEnter(Collision collision) 
    {
        //Checking for collision with the player
        if (collision.collider.tag == "Player")
        {
            //This can solve the race condition problem mentioned earlier, 
			//if(ScoreManager == null)
			//{
			//	ScoreManager = FindObjectOfType<ScoreManager>();
			//}
            //ScoreManager.UpdateScore();
            
            //Destroy the coin object
            Destroy(this.gameObject);
            //Grab the singleton ScoreManagerInstance and update the score.
            ScoreManager.ScoreManagerInstance.UpdateScore();
        }
    }
}
