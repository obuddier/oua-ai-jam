using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private GameObject agent;
    private TMP_Text text;
    private CanvasGroup blackScreen;
    private CanvasGroup lastText;
    private CharacterMovement characterMovement;
    
    bool isFinished = false;
    public bool isEnd = false;
    bool isGoingToMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.Find("Char");
        text = GameObject.Find("LevelCanvas").transform.Find("StageNameTxt").GetComponent<TMP_Text>();
        blackScreen = GameObject.Find("LevelCanvas").transform.Find("BlackScreen").GetComponent<CanvasGroup>();
        lastText = GameObject.Find("LevelCanvas").transform.Find("LastText").GetComponent<CanvasGroup>();
        characterMovement = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (isEnd)
        {
            blackScreen.alpha += Time.deltaTime;
        }
        
        if(blackScreen.alpha >= 1)
        {
            isEnd = false;
            lastText.alpha += Time.deltaTime;
            StartCoroutine(GoToMenu());
        }
        
        if(isGoingToMenu)
        {
            lastText.alpha -= Time.deltaTime;
            
            if(lastText.alpha <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            Debug.Log("Game Over");
            text.text = "And Acceptance";
            Destroy(agent.gameObject);
            StartCoroutine(EndScene());
            
            isFinished = true;
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(5);
        characterMovement.enabled = false;
        isEnd = true;
    }

    public IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(22);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        blackScreen.alpha = .999f;
        isGoingToMenu = true;
    }
}
