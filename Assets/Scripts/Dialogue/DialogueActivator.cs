#region 'Using' information
using UnityEngine;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

/// <summary>
/// Dialogue responses are no longer in the game, but deleting the scripts caused more troubles than was worth dealing with.
/// </summary>

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

    public void Interact(PlayerInteract player) 
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>()) /// See summary.
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
