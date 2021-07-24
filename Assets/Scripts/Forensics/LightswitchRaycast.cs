using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightswitchRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 2; // How far the player can reach.
    private LightswitchController interactiveObject;

    [SerializeField] private Image crosshair;

    private void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength))
        {
            var raycastObj = hit.collider.gameObject.GetComponent<LightswitchController>();
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
                interactiveObject.InteractSwitch();
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
            crosshair.color = Color.clear;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
