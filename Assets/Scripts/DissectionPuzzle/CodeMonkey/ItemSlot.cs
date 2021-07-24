#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource squishy; // The 'squish' sound effect

    public DragDrop animalPart; // Should determine which piece the player is moving.

    #region animal slot booleans
    [SerializeField] public bool frogHeadSlot = false;
    [SerializeField] public bool frogLegsSlot = false;

    [SerializeField] public bool birdHeadSlot = false;
    [SerializeField] public bool birdLegsSlot = false;

    [SerializeField] public bool fishHeadSlot = false;
    [SerializeField] public bool fishLegsSlot = false;
    #endregion

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        
            if (frogHeadSlot == true)
            {
                squishy.Play(); // Plays the squishy sound effect when an object is placed.
                animalPart.isDraggable = false;
            }
        }
    }
}
