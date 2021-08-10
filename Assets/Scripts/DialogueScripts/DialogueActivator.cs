using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private AudioSource staticOn;

    private void Awake() // Will be responsible for playing the static noise when the player interacts with the intercom.
    {
        staticOn.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // Lets you interact with the intercom when you get close.
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other) // Stops you from interacting with the intercom when you've moved away.
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
        player.DialogueUI.ShowDialogue(dialogueObject); // Shows the dialogue when the player interacts with the object.
        staticOn.Play(); // Plays the static sound effect when the player interacts with the object.
    }
}
