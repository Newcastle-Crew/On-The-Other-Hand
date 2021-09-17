#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

[System.Serializable]
public enum Part {
    Head,
    Legs,
} 

[System.Serializable]
public enum Animal {
    Frog,
    Bird,
    Fish,
}

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Animal animal;
    public Part part;

    public ItemSlot currentSlot;
    public ItemSlot oldSlot = null;

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
        canvasGroup.alpha = 0.7f;

        if (currentSlot != null) {
            currentSlot.currentOccupier = null;
        }
        oldSlot = currentSlot;
        currentSlot = null;
    }

    public void OnDrag(PointerEventData eventData) {
        // Move with the mouse
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        if (currentSlot == null) {
            // We didn't get put on a slot.
            currentSlot = oldSlot;
            currentSlot.currentOccupier = this;
        }

        rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
    }
}
