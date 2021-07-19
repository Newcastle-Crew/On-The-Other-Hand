using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter(Collider other) // Will make the dialogue box appear when you get close.
    {
    }

    private void OnTriggerExit(Collider other) // Will make the dialogue box disappear when you go away.
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract player))
        {
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(PlayerInteract player) 
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
