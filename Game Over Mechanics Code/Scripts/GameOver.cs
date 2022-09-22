using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOverChecker();
    }

    public void GameOverChecker()
    {
        //Attach the boolean that is turned on here to grabbing block functionality. 

        //CURRENT COUNT IS SET TO 8 BECAUSE FOR SOME REASON IT COUNTS THE BLOCK GOING PAST THE BARRIER FOUR TIMES
        if (PlayerController.blockFallCount == 8)
        {
            PlayerController.gameOver = true;

            Debug.Log("GAME IS OVER YOU HAVE LOST"); //Plays infinitely, needs fixing 
        }
    }
}
