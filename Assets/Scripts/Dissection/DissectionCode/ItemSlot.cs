#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public AudioSource squishy; // The source of the squish sound effect that plays whenever a part is placed on a head or leg slot.
    public bool isTable = false; // isTable bools will determine whether or not that slot makes the squish sound effect play.
    public Animal animal; // Determines which animal the current part was once part of.
    public Part part; // Determines whether or not that part is legs or a head.
    public DragDrop currentOccupier = null; // Used with slots to determine what is currently in the slot. Set to NULL (aka 'nothing' by default.)

    public void OnDrop(PointerEventData eventData) 
    {
        var drag_drop = eventData.pointerDrag.GetComponent<DragDrop>();
        if (drag_drop == null) return;

        if (currentOccupier != null || (!isTable && drag_drop.part != part)) return;

        currentOccupier = drag_drop;
        drag_drop.currentSlot = this;

        if (squishy != null && !isTable) squishy.Play();

        if (drag_drop.animal == animal && !isTable) // Checks if the part in the slot matches the 'correct' part for that slot. If it does..
        {
            GetComponentInParent<DissectionPuzzle>().CheckForWin(); // ... then it's correct, and a check for the puzzle being won is run. Code continues in DissectionPuzzle.cs
        }
    }

    public bool IsCorrect() 
    {
        if (isTable) return true; // If isTable returns true (as in, the slot IS a table) then the code does not continue.
        if (currentOccupier == null) return false; // if 'currentOccupier is equal to null' returns false (as in, there IS something occupying the slot) then the code continues.

        return currentOccupier.animal == animal; // Gives the 'IsCorrect' bool for that slot a true or false marker if the animal is in the correct slot. True if it is, false if it isn't.
    }
}
