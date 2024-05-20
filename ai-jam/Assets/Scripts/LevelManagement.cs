using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public GameObject pausePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            //oyun durmalý
        }
    }

    public void ResumeLevel()
    {
        pausePanel.SetActive(false);
        //oyun akmaya devam etmeli
    }

    public void OpenNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

