#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public AudioSource squishy;

    public bool isTable = false;
    public Animal animal;
    public Part part;

    public DragDrop currentOccupier = null;

    public void OnDrop(PointerEventData eventData) {
        var drag_drop = eventData.pointerDrag.GetComponent<DragDrop>();
        if (drag_drop == null) return;

        if (currentOccupier != null || (!isTable && drag_drop.part != part)) return;

        currentOccupier = drag_drop;
        drag_drop.currentSlot = this;

        if (squishy != null && !isTable) squishy.Play();

        if (drag_drop.animal == animal && !isTable) {
            // Correct! Check for a win
            GetComponentInParent<DissectionPuzzle>().CheckForWin();
        }
    }

    public bool IsCorrect() {
        if (isTable) return true;
        if (currentOccupier == null) return false;

        return currentOccupier.animal == animal;
    }
}
