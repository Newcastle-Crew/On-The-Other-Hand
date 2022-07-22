#region 'Using' information
using System;
using System.Collections;
using UnityEngine;
using TMPro;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox; // Will be responsible for the box disappearing after dialogue concludes.
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen {get; private set;} // Checks if the UI is open - good for popping up in proximity to a speaker.

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start() // Always gets the typewriter effect so that the words come in slowly.
    {        
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

        public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            
            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;
            
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0)); // Requires left click to be pressed before going to the next page of dialogue.
        }

        if (dialogueObject.HasResponses)
        {
            Cursor.visible = true; // Makes the cursor visible if there are buttons for the player to click.
            responseHandler.ShowResponses(dialogueObject.Responses); // If this is a dialogue box with responses, show them.
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
    }
}
