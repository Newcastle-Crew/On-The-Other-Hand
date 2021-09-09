#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    [SerializeField] private Canvas canvas;

    #region animal piece booleans
    [SerializeField] public bool frogHead = false;
    [SerializeField] public bool frogLegs = false;

    [SerializeField] public bool birdHead = false;
    [SerializeField] public bool birdLegs = false;

    [SerializeField] public bool fishHead = false;
    [SerializeField] public bool fishLegs = false;
    #endregion

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public Vector3 defaultPos; // The default position of a part being moved.
    public bool droppedOnSlot; // A boolean for checking if the part was dropped into a slot or not.

    public bool isDraggable = true;

    private void Start() 
    {
        defaultPos = transform.position; // Sets the part's default position as the one it started in.
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        defaultPos = transform.position; // Sets the part's default position as the one it started in.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
            canvasGroup.alpha = .7f; // Makes the item slightly transparent when it's being moved.
            canvasGroup.blocksRaycasts = false;

            eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false; // Assumes the item hasn't been dropped on a slot until the player lets go.
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (frogHead||frogLegs||birdHead||birdLegs||fishHead||fishLegs && isDraggable)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (droppedOnSlot == false)
        {
            transform.position = defaultPos; // If the item wasn't dropped on a slot, return it to its original position.
        }

        if (frogHead||frogLegs||birdHead||birdLegs||fishHead||fishLegs && isDraggable)
        {
            canvasGroup.alpha = 1f; // Restores the image's regular transparency.
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    }