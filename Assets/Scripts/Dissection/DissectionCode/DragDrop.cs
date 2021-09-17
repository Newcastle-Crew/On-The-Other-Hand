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

    Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    void Awake() {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
        currentSlot.currentOccupier = this;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.7f; // Makes the animal part slightly transparent when it's being dragged.

        if (currentSlot != null) 
        {
            currentSlot.currentOccupier = null;
        }

        oldSlot = currentSlot;
        currentSlot = null;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Moves the animal part with the mouse
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        if (currentSlot == null) // if the item wasn't put on a slot.
        {
            currentSlot = oldSlot;
            currentSlot.currentOccupier = this;
        }

        rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
    }
}
