using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 2; // The distance at which you can interact with an object.
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excludeLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E; // Will open doors with the E key.
        [SerializeField] private Image crosshair = null; // Allows the crosshair image to be added.
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Start() 
        {      
            crosshair.color = Color.clear; // Stops the crosshair from appearing when it shouldn't by making it invisible as the game starts.
        }

        private void Update() 
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; // Makes sure the player can't interact with non-interactable objects.

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag)) // If you look at an interactable object...
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true); // Makes the 'hand' crosshair visible when you look at an interactive object.
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if(Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
                if(isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.white; // Makes the crosshair appear when it's over something it can interact with.
            }
            
            else
            {
                crosshair.color = Color.clear; // Otherwise, makes the crosshair invisible.
                isCrosshairActive = false;
            }
        }
    }

}

