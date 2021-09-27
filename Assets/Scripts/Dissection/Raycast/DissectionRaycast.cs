#region 'Using' info
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class DissectionRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 2; // How far the player can reach.
    private DissectionController interactiveObject;

        #region Canvases
    [SerializeField] public Canvas otherCanvas; // Requires a canvas to work, so drag one into the inspector.
    [SerializeField] public Canvas regularCanvas; // Requires a canvas to work, so drag one into the inspector.
    #endregion

    [SerializeField] private Image crosshair;

    private void Start() 
    {      
        crosshair.color = Color.clear; // Stops the crosshair from appearing when it shouldn't by making it invisible as the game starts.
                    
            if (interactiveObject)
            {
                interactiveObject = GetComponent<DissectionController>();
            }
    }

    private void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength))
        {
            var raycastObj = hit.collider.gameObject.GetComponent<DissectionController>();

            if(raycastObj != null)
            {
                interactiveObject = raycastObj;
                CrosshairChange(true);
            }
            else
            {
                ClearInteraction();
            }
        }
        else
        {
            ClearInteraction();
        }

        if(interactiveObject != null)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                otherCanvas.gameObject.SetActive(true); // Shows the UI of the puzzle.
                regularCanvas.gameObject.SetActive(false);
                Cursor.visible = true; // Makes the cursor visible.
                Cursor.lockState = CursorLockMode.None; // Allows the player to move their cursor around and click freely.
            }
        }
    }

    private void ClearInteraction()
    {
        if (interactiveObject != null)
        {
            CrosshairChange(false);
            interactiveObject = null;
        }
    }

    void CrosshairChange(bool on)
    {
        if(on)
        {
            crosshair.color = Color.white;
        }
        else
        {
            crosshair.color = Color.clear;
        }
    }
}
