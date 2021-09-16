#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public enum Slots
{
    Head,
    Legs,
    Table
} // 0 = HEAD slots, 1 = LEGS slots, 2 = TABLE slots.

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource squishy; // The 'squish' sound effect
    [SerializeField] public Slots thisSlot; // Adds a drop down menu to all slots in the editor. Choose between Head, Legs or Table.

    private DragDrop dragDrop; // Lets you call in various ints and bools from the DragDrop class.
    public DragDrop occupier = null;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
        eventData.pointerDrag.GetComponent<DragDrop>().defaultPos = transform.position;

        if (eventData.pointerDrag != null) // If the player stops holding click...
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // Gets the part's current position.

            if (thisSlot == Slots.Head || thisSlot == Slots.Legs)
            {
                squishy.Play(); // Squishy sound effect plays if a piece is placed on a head OR leg slot.
                dragDrop.isDraggable = false;
            }

            if (thisSlot == Slots.Table)
            {
                dragDrop.isDraggable = false;
                // If I ever want table slots to do something, this is the place to put that code.
            }
        }
    }
}
