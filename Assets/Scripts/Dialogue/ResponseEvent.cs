#region 'Using' information
using UnityEngine;
using UnityEngine.Events;
#endregion

// I used this tutorial --> https://www.youtube.com/playlist?list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA
// Repo here --> https://github.com/Pattrigue/DialogueSystem

/// <summary>
/// Dialogue responses are no longer in the game, but deleting the scripts caused more troubles than was worth dealing with.
/// </summary>

[System.Serializable]
public class ResponseEvent
{
    [HideInInspector] public string name;
    [SerializeField] private UnityEvent onPickedResponse;

    public UnityEvent OnPickedResponse => onPickedResponse;
}