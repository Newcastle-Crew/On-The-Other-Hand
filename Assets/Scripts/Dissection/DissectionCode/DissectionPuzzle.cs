using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissectionPuzzle : MonoBehaviour
{
    ItemSlot[] slots;
    bool alreadyWon = false;

    void Awake()
    {
        slots = GetComponentsInChildren<ItemSlot>();
    }

    public void CheckForWin() {
        // If we already won we don't want to do whatever cool happens once more, probably
        if (alreadyWon) return;

        foreach (var slot in slots) {
            if (!slot.IsCorrect()) return;
        }

        alreadyWon = true;

        Debug.Log("Completed the dissection puzzle!");
        // Insert code to do whatever should happen after winning here
    }
}
