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

    private void Update() // This code runs during every frame.
    {   
        if (dialogueUI.IsOpen) // Stops the player from spamming extra dialogue boxes while the dialogue box is appearing.
        return; 
    }

    private void OnTriggerStay(Collider other) // When the player stands in an object's trigger box...
    {
        if (Input.GetKeyDown(KeyCode.E)) // and if the player presses E... 
        {
            Interactable?.Interact(player:this); // and the object can be interacted with, interact with it.
        }
    }

}