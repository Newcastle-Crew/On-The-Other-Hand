using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    
public class TakeBlood : MonoBehaviour
{
    public IInteractable Interactable { get; set; }

    public bool StabbyStab = false; // Healing mechanic - tells the PlayerHealth class when to run the RestoreHealth method.

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) // If the player presses E and the object can be interacted with, run this code.
        {
            StabbyStab = true; // Begins the 'restore health' method in the PlayerHealth class.
            gameObject.SetActive(false); // Destroys the needle object.
        }
    }
     
}

}
