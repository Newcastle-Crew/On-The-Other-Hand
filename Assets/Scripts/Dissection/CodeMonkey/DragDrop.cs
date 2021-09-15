#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    [SerializeField] public int anAnimalPart; // '1' is for animal HEADS, '2' is for animal LEGS.
    [SerializeField] public int aSpecification; // 1 is for frog, 2 is for bird, 3 is for fish.

    #region  rectTransform, Canvas and canvasGroup
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    #endregion

    public Vector3 defaultPos; // The default position of a part being moved.
    public bool droppedOnSlot; // A boolean for checking if the part was dropped into a slot or not.
    public bool isDraggable = true; // Does what it says on the tin - determines if the animal part is draggable or not.

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
        if (anAnimalPart == 1 || anAnimalPart == 2) // If it's head or legs and can be dragged...
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Then the animal part will move with the mouse.
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (droppedOnSlot == false)
        {
            transform.position = defaultPos; // If the item wasn't dropped on a slot, return it to its original position.
        }

        if (anAnimalPart == 1 || anAnimalPart == 2)
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