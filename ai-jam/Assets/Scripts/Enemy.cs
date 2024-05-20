using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
            agent.speed = 0f;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}
