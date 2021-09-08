using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Dialogue Variables
    
    [SerializeField] private DialogueUI dialogueUI; // Will be used to only show UI when the player is close to a dialogue object.

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; } // Code for determining if an object can be interacted with.
    #endregion

    private bool somethingOpen; // A bool to check if 'something' (an 'are you sure' box or intercom box) has opened.

    private void Update() // This code runs during every frame.
    {   
        somethingOpen = dialogueUI.IsOpen; // Stops the player from spamming extra dialogue boxes while the dialogue box is open.
    }

    private void OnTriggerStay(Collider other) // When the player stands in an object's trigger box...
    {
        if (Input.GetKeyDown(KeyCode.E) && somethingOpen == false) // and if the player presses E while a dialogue box is not currently open... 
        {
            Interactable?.Interact(player:this); // and the object can be interacted with, interact with it.
        }
    }

}