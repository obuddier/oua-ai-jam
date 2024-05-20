using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject gameName;

    private void Start()
    {
        credits.SetActive(false);
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

}
