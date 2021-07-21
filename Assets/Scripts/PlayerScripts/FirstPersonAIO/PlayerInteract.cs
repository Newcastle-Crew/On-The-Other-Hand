using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Dialogue Variables
    [SerializeField] private DialogueUI dialogueUI; // Will be used to only show UI when the player is close to a speaker.

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }
    #endregion
    
    private void Start() /// Start is called before the first frame update
    {        
        
    }

    private void Update()
    {   
        if (dialogueUI.IsOpen) // Stops the player from spamming extra dialogue boxes while the dialogue box is appearing.
        return; 

        if (Input.GetKeyDown(KeyCode.E)) // If the player presses E and the object can be interacted with, interact with it.
        {
            Interactable?.Interact(player:this);
        }
    }

}