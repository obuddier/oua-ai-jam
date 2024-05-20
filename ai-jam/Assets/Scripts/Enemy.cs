using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private CanvasGroup diePanel;
    
    bool isDied = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        diePanel = GameObject.Find("LevelCanvas").transform.Find("DiePanel").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDied)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        agent.SetDestination(target.position);
        
        if (Vector3.Distance(transform.position, target.position) < 10.0f)
        {
            agent.speed = 10f;
        }
        else
        {
            agent.speed = 12f;
        }
        
        if(agent.velocity.magnitude > 0.5f)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
        }
        
        if (Vector3.Distance(transform.position, target.position) < 1.5f)
        {
            Debug.Log("Game Over");
            isDied = true;
            Time.timeScale = 0;
            diePanel.alpha = 1;
            agent.speed = 0f;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}
