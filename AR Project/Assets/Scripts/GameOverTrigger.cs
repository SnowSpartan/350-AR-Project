using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTrigger : MonoBehaviour
{
    public Boolean canLose = false;
    public Text gameOverText;
    public Button playAgainButton;
    public Image playAgainImage;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("YouLose").GetComponent<Text>();
        playAgainButton = gameOverText.GetComponentInChildren<Button>();
        playAgainImage = gameOverText.GetComponentInChildren<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canLose)
        {
            if (other.CompareTag("Block"))
            {
                gameOverText.enabled = true;
                playAgainButton.enabled = true;
                playAgainImage.enabled = true;
            }
        }
    }
}
