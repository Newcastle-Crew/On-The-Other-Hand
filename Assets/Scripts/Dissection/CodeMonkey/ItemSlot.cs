#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource squishy; // The 'squish' sound effect
    [SerializeField] public int aSlot; // 1 is for head slots, 2 is for leg slots, 3 is for table slots.

    public DragDrop animalPart; // Determines which piece the player is moving.
    public int anAnimalPart;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
        eventData.pointerDrag.GetComponent<DragDrop>().defaultPos = transform.position;
        
        if (eventData.pointerDrag != null) // If the player stops holding click...
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // Gets the part's current position.
        
            if (aSlot == 1 || aSlot == 2)
            {
                squishy.Play(); // Plays the squishy sound effect when an object is placed on a head OR body slot.
                animalPart.isDraggable = false;
            }
            else if (aSlot == 3)
            {
                animalPart.isDraggable = false; // Does not play the squishy sound effect when the part if placed on a table slot.
            }

            if (aSlot == 1 && anAnimalPart == 1)
            {
                animalPart.isDraggable = false;
            }
        }
    }
}
