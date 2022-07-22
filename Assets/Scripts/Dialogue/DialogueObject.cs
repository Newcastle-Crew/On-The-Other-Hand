#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem
// It'd be great to see the 'yes' and 'no' buttons in the middle of the screen, or at the very least separated.

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject // Template for dialogue objects to draw fields from.
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue; // Stops any outside code from overwriting the desired dialogue.

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}
