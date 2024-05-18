using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        PickUpKey();
    }

 private void PickUpKey()
    {
        Destroy(gameObject);
        
        //kapýyý aç()
    }
}
