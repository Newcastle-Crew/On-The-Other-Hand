#region 'Using' information
using System;
using System.Collections;
using UnityEngine;
using TMPro;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

/// <summary>
/// Dialogue responses are no longer in the game, but deleting the scripts caused more troubles than was worth dealing with.
/// </summary>

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox; // Will be responsible for the box disappearing after dialogue concludes.
    [SerializeField] private TMP_Text textLabel;
    private FirstPersonAIO playerController;

    public bool IsOpen {get; private set;} // Checks if the UI is open - good for popping up in proximity to a speaker.

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Awake()
    {
        playerController = FindObjectOfType<FirstPersonAIO>();
    }

    private void Start() // Always gets the typewriter effect so that the words come in slowly.
    {        
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
        playerController.dialogueOpen = true;
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents) /// See summary.
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            Cursor.visible = true; // Makes the cursor visible if there are buttons for the player to click.

            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;
            
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0)); // Requires left click to be pressed before going to the next page of dialogue.
        }

        if (dialogueObject.HasResponses) /// See summary. This script in particular had a lot of issues with the change.
        {
            responseHandler.ShowResponses(dialogueObject.Responses); /// Dialogue responses are no longer in the game - redundant
        }

        else
        {
            CloseDialogueBox(); // If there are no responses, close the dialogue box.
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            { 
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    {
        Cursor.visible = false; // Makes the cursor invisible when the player closes the dialogue box.
        IsOpen = false; // Closes the dialogue box when you've finished reading the text & left-clicked.
        dialogueBox.SetActive(false); // Tells unity to hide the box's UI. 
        textLabel.text = string.Empty; // Removes the text.
        playerController.dialogueOpen = false;
    }
}
