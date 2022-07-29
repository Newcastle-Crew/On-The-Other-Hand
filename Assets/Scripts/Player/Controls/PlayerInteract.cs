using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Dialogue Variables
    
    [SerializeField] private DialogueUI dialogueUI; // Will be used to only show UI when the player is close to a dialogue object.
    [SerializeField] private float rayLength = 2;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; } // Code for determining if an object can be interacted with.
    #endregion

    private bool somethingOpen; // A bool to check if 'something' (an 'are you sure' box or intercom box) has opened.
    private RaycastHit hit;
    private GameObject hitObject = null;

    private void Update() // This code runs during every frame.
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            Interactable = hit.collider.GetComponent<IInteractable>();
            Debug.Log(Interactable);
        }
        else
            Interactable = null;

        TryInteractDialogue();
    }

    private bool TryInteractDialogue()
    {
        if(Interactable == null) return false;
        if(dialogueUI.IsOpen) return false;
        if(!Input.GetKeyDown(KeyCode.E)) return false;
        Interactable?.Interact(player:this); // and the object can be interacted with, interact with it.
        return true;
    }
}