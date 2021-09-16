#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

public enum Pieces // 0 = HEAD pieces, 1 = LEG pieces.
{Head,Legs,} 

public enum Type // 0 = FROG, 1 = BIRD, 2 = FISH.
{Frog,Bird,Fish}

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    #region  rectTransform, Canvas and canvasGroup
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    #endregion

    [SerializeField] private Pieces animalPieces; // Adds a drop down menu to all animal pieces in the editor. Choose between Head or Legs.
    [SerializeField] private Type animalType; // Adds another drop down menu to all animal pieces in the editor. Choose between Frog, Bird or Fish.

    public Vector3 defaultPos; // The default position of a part being moved.
    public bool droppedOnSlot; // A boolean for checking if the part was dropped into a slot or not.
    public bool isDraggable = true; // Determines if the animal part is draggable or not. True by default, false when in the right place.

    private bool headMoving = false;
    private bool legsMoving = false;

    public ItemSlot current_slot = null;

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
        canvasGroup.alpha = .7f; // Makes the part slightly transparent when it's being moved.
        canvasGroup.blocksRaycasts = false;
        eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false; // Assumes the part hasn't been dropped on a slot until the player lets go.

        if (animalPieces == Pieces.Head)
        {
            Debug.Log("A Head is being dragged.");
            headMoving = true;
        }

        if (animalPieces == Pieces.Legs)
        {
            Debug.Log("A Pair of Legs is being dragged.");
            legsMoving = true;
        }
    }

    public void OnDrag(PointerEventData eventData) // If it's being dragged...
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Then the animal part will move with the mouse.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restores the image's regular transparency.
        canvasGroup.blocksRaycasts = true;

        if (headMoving == true && current_slot)
        {

        }

        if (droppedOnSlot == false) // If the item wasn't dropped on a slot...
        {
            transform.position = defaultPos; //...then it will be returned to its previous position.
        }
    }

    public void OnPointerDown(PointerEventData eventData)
        {

        }

    public void OnDrop(PointerEventData eventData)
        {
        
        }

    }