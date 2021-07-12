using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox; // Will be responsible for the box disappearing after dialogue concludes.
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen {get; private set;} // Checks if the UI is open - good for popping up in proximity to a speaker.
    private TypewriterEffect typewriterEffect;

    private void Start() // Always gets the typewriter effect so that the words come in slowly.
    {        
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true; // Opens the dialogue box when you're near a speaker.
        dialogueBox.SetActive(true);
        StartCoroutine(routine:StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0)); // Requires space to be pressed before going to the next line.
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        IsOpen = false; // Closes the dialogue box when you're not near a speaker.
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
