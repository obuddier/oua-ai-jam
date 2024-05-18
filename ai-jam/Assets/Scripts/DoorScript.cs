using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private string[] keys;
    // Update is called once per frame
    void Update()
    {
        keys = PlayerPrefs.GetString("Keys").Split(",");
        if (keys.Contains(this.gameObject.name + "_Key"))
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Open");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
