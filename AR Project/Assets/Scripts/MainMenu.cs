using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject gameCredits;
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameTest");
    }

    public void CreditsButton()
    {
        gameCredits.SetActive(true);
    }

    public void CloseButton()
    {
        gameCredits.SetActive(false);
    }
}
