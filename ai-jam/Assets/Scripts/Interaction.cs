using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3.0f))
        {
            if (hit.transform.gameObject.layer == 6)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.CompareTag("Key"))
                    {
                        PlayerPrefs.SetString("Keys", PlayerPrefs.GetString("Keys") + hit.collider.name + ",");
                        Destroy(hit.collider.gameObject);
                    }
                    
                    if(hit.collider.name == "MainDoor")
                    {
                        hit.collider.GetComponent<Animator>().SetTrigger("Open");
                        hit.collider.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
        }
    }
}
