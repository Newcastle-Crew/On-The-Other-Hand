using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource squishy;

    public DragDrop animalPart; // Determines which piece the player is moving.

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            squishy.Play();
            
            if (animalPart.frogHead == true)
            {
                
            }
        }
    }
}
