#region 'Using' information
using UnityEngine;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject; // Lets you attach text that'll appear when the player interacts with a dialogue object.

    [Header ("Audio")]
        [SerializeField] private AudioSource interactiveObjectAudioSource = null; // A place for you to drag the 'opening' audio source.
        [SerializeField] private float interactiveSoundDelay = 0; // Can delay the sound effect's beginning time.

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter(Collider other) // lets you interact with the dialogue object when you get close.
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other) // Stops you from interacting with the dialogue object when you've moved away.
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
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>()) // If the dialogue object has choices, shows them.
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                player.DialogueUI.AddResponseEvents(responseEvents.Events); // Adds the buttons & their events to the inspector.
                break;
            }
        }

        player.DialogueUI.ShowDialogue(dialogueObject); // Shows the dialogue when the player interacts with the object.
        interactiveObjectAudioSource.PlayDelayed(interactiveSoundDelay); // Plays the desired sound effect when the player interacts with the object.
    }
}
