using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject credits;

    private void Start()
    {
        credits.SetActive(false);
    }


    public void NewGame()
    {
        SceneManager.LoadScene("GameMap");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }

}
