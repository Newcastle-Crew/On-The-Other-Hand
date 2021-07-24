using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    [SerializeField] private Canvas canvas;

    #region animal parts booleans
    [SerializeField] public bool frogHead = false;
    [SerializeField] public bool frogLegs = false;

    [SerializeField] public bool birdHead = false;
    [SerializeField] public bool birdLegs = false;

    [SerializeField] public bool fishHead = false;
    [SerializeField] public bool fishLegs = false;
    #endregion

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .8f; // Makes the item slightly transparent when it's being moved.
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Keeps the item as close to the mouse as possible.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         canvasGroup.alpha = 1f; // Restores the image's regular transparency.
         canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    }