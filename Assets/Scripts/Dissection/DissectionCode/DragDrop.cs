#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

[System.Serializable]
public enum Part // An enum for the part of the animal you're moving.
{
    Head,
    Legs,
} 

[System.Serializable]
public enum Animal // An enum for the type of animal you're moving.
{
    Frog,
    Bird,
    Fish,
}

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Animal animal;
    public Part part;

    public ItemSlot currentSlot; // Checks which slot the item is currently in.
    public ItemSlot oldSlot = null; // Checks which slot the item was previously in.

    Canvas canvas; // The canvas is the UI that the player sees.
    CanvasGroup canvasGroup; // Canvasgroups let you change certain properties of a canvas and its children like opacity, interactability, etc.
    RectTransform rectTransform; // rectTransforms let you control the position, size, alignment and pivots of a rectangle.

    void Awake() 
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
        currentSlot.currentOccupier = this;
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.7f; // Makes the animal part slightly transparent when it's being dragged.

        if (currentSlot != null) // the CurrentSlot becomes null, allowing something else to be placed inside it.
        {
            currentSlot.currentOccupier = null;
        }

        oldSlot = currentSlot; // Sets the slot that the part just left as the 'current slot'. This makes it the slot that the part will snap back to if it's dropped somewhere wrong.
        currentSlot = null; // Sets the current spot to null, so it's ready to be changed into the slot that the part gets dropped into.
    }

    public void OnDrag(PointerEventData eventData) 
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Moves the animal part with the mouse
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        canvasGroup.alpha = 1.0f; // Makes the animal part fully opaque when it's not being dragged.
        canvasGroup.blocksRaycasts = true;

        if (currentSlot == null) // This code runs if the item wasn't put onto a slot.
        {
            currentSlot = oldSlot; // Puts the item back in the slot it was in previously.
            currentSlot.currentOccupier = this; // Keeps the current occupier variable the same.
        }

        rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
    }
}
