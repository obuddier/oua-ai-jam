using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public GameObject pausePanel;
    private CanvasGroup fadePanel;
    private CharacterMovement characterMovement;
    
    private bool endFade;
    
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        fadePanel = GameObject.Find("LevelCanvas").transform.Find("FadePanel").GetComponent<CanvasGroup>();
        characterMovement = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>();
        
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartCoroutine(StartScene());
            characterMovement.enabled = false;
        }
    }

    public IEnumerator StartScene()
    {
        yield return new WaitForSeconds(8);
        characterMovement.enabled = true;
        endFade = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (endFade)
        {
            fadePanel.alpha -= Time.deltaTime;
        }
        
        if(Input.GetKey(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            //oyun durmalı
        }
    }

    public void ResumeLevel()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
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

