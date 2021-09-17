#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class DissectionPuzzle : MonoBehaviour
{
    ItemSlot[] slots;
    bool alreadyWon = false;

    void Awake()
    {
        slots = GetComponentsInChildren<ItemSlot>();
    }

    public void CheckForWin() 
    {
        if (alreadyWon) return; // If we already won we don't want to do whatever cool happens once more, probably

        foreach (var slot in slots) 
        {
            if (!slot.IsCorrect()) return; // Checks to make sure every slot is correct. before proceeding.
        }

        alreadyWon = true;

        Debug.Log("Completed the dissection puzzle!");
        // Insert code to do whatever should happen after winning here \/
    }
}
