using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Credit : Brackeys YT

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameOver)
        {
            Paused();
        }
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        PlayerController.gameOver = false;
        PlayerController.blockFallCount = 0;
    }
    
    void Paused()
    {
        pauseMenuUI.SetActive(true);
    }
}
