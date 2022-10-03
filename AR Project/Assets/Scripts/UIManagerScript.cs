using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{

    //Turn Functionality Assets
    public Button playerTurn;
    public Image playerText;
    public Button expandButton;
    public Button yourTurn;

    //Assets for Pause Menu UI
    [SerializeField] GameObject pauseMenu;
    
    //Assets for Settings Menu UI
    [SerializeField] GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn.onClick.AddListener(delegate { nextPlayer(); });
        expandButton.onClick.AddListener(delegate { expandPlayerButton(); });
        yourTurn.onClick.AddListener(delegate { startTurn(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPlayer()
    {
        //playerText.text = "Pass phone to Next Player";
        //playerTurn.gameObject.SetActive(false);
        //expandButton.gameObject.SetActive(true);
        //playerText.gameObject.SetActive(false);
        playerText.gameObject.SetActive(false);
        playerTurn.gameObject.SetActive(false);
        yourTurn.gameObject.SetActive(true);

    }


    public void expandPlayerButton()
    {
        //playerText.gameObject.SetActive(true);
        //playerText.text = "Pass Phone to next Player";
        //yourTurn.gameObject.SetActive(true);
        //expandButton.gameObject.SetActive(false);
        playerTurn.gameObject.SetActive(true);
        playerText.gameObject.SetActive(true);
        expandButton.gameObject.SetActive(false);

    }

    public void startTurn()
    {
        yourTurn.gameObject.SetActive(false);
        expandButton.gameObject.SetActive(true);
        //expandButton.gameObject.SetActive(true);
    }


    //functionality for Pause Menu UI
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //functionality for Settings Menu UI
    public void OpenSettings()
    {
        SettingsMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
        //SceneManager.LoadScene("MainMenu");
    }

    public void Close()
    {
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
