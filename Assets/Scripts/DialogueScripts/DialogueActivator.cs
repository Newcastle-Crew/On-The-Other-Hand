using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter(Collider other) // Will make the dialogue box appear when you get close.
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract player))
        {
            player.Interactable = this;
        }
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
