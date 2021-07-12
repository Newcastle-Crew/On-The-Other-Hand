using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject // Template for dialogue objects to draw fields from.
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue; // Stops any outside code from overwriting the desired dialogue.
}
