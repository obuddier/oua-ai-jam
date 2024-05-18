using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject anahtar;
    public void Interact()
    {
        PickUpKey();
    }

 private void PickUpKey()
    {
        Destroy(gameObject);
    }
}
