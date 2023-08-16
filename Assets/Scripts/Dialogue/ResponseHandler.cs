#region 'Using' information
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

/// <summary>
/// Dialogue responses are no longer in the game, but deleting the scripts caused more troubles than was worth dealing with.
/// </summary>

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;
    private ResponseEvent[] responseEvents; /// see summary

    private List<GameObject> tempResponseButtons = new List<GameObject>(); /// see summary

    private void Start()
    { dialogueUI = GetComponent<DialogueUI>(); }

    public void AddResponseEvents(ResponseEvent[] responseEvents)  /// see summary
    { this.responseEvents = responseEvents; }
    
    public void ShowResponses(Response[] responses)  /// see summary
    {
        float responseBoxHeight = 0;

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;
            
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));
            
            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response, int responseIndex)  /// see summary
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        { Destroy(button); }

        tempResponseButtons.Clear();

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        { responseEvents[responseIndex].OnPickedResponse?.Invoke(); }

        responseEvents = null;

        if (response.DialogueObject)
        { dialogueUI.ShowDialogue(response.DialogueObject); }
        else
        { dialogueUI.CloseDialogueBox(); }
    }
}