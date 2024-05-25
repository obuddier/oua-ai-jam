using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject gameName;
    public GameObject howToPlayPanel;

    private void Start()
    {
        credits.SetActive(false);
        howToPlayPanel.SetActive(false);
    }


    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        gameName.SetActive(false);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
        gameName.SetActive(true);
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        gameName.SetActive(false);
    }
    public void HideHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        gameName.SetActive(true);
    }

}
