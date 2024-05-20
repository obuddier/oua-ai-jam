using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private GameObject agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.Find("Char");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(agent.gameObject);
        }
    }
}
