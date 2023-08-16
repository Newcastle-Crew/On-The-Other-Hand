#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

/// <summary>
/// Dialogue responses are no longer in the game, but deleting the scripts caused more troubles than was worth dealing with.
/// </summary>

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject // Template for dialogue objects to draw fields from.
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue; // Stops any outside code from overwriting the desired dialogue.

    public bool HasResponses => Responses != null && Responses.Length > 0; /// See summary

    public Response[] Responses => responses; /// See summary
}
