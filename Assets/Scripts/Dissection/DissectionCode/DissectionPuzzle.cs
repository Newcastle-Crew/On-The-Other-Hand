#region 'Using' information
using UnityEngine;
#endregion

public class DissectionPuzzle : Puzzle
{
    [SerializeField] public Canvas dissectionCanvas; // Requires a canvas to work, so drag the dissection canvas into the inspector.
    [SerializeField] public Canvas regularCanvas; // Requires a canvas to work, so drag the regular UI canvas into the inspector.

    ItemSlot[] slots;
    bool alreadyWon = false;

    protected override void Awake()
    {
        base.Awake();
        slots = GetComponentsInChildren<ItemSlot>();
    }

    public void CheckForWin() // Code begins in ItemSlot.cs
    {
        if (alreadyWon) // If the player has already won the dissection puzzle and tries to enter the correct solution again, it will close the puzzle.
        {
            dissectionCanvas.gameObject.SetActive(false); // Hides the dissection puzzle.
            regularCanvas.gameObject.SetActive(true); // Unhides the regular UI.
            Cursor.visible = false; // Makes the cursor invisible.
            Cursor.lockState = CursorLockMode.Locked; // Stops the player from moving their cursor around and clicking freely.
        }

        foreach (var slot in slots) 
        {
            if (!slot.IsCorrect()) return; // Checks to make sure every slot is correct before carrying out the code below.
        }

        alreadyWon = true;

        Debug.Log("Completed the dissection puzzle!");
        dissectionCanvas.gameObject.SetActive(false); // Hides the dissection puzzle.
        regularCanvas.gameObject.SetActive(true); // Unhides the regular UI.
        Cursor.visible = false; // Makes the cursor invisible.
        Cursor.lockState = CursorLockMode.Locked; // Stops the player from moving their cursor around and clicking freely.
    }
}
