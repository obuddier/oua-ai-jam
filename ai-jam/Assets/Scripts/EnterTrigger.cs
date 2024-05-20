using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnterTrigger : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GameObject.Find("Char").GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.enabled = true;
        }
    }
}
