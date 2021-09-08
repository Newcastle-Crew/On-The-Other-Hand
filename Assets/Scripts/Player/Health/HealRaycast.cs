using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class HealRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 2; // The distance at which you can interact with a needle.
        [SerializeField] private LayerMask layerMaskHeal; // The layer that needles will be on.
        [SerializeField] private string excludeLayerName = null;

        private HealItemController raycastedObject;
        [SerializeField] private KeyCode needleUp = KeyCode.E; // Will use needles with the E key.
        [SerializeField] private Image crosshair = null; // Allows the crosshair image to be added.


        private bool isCrosshairActive;
        private bool doOnce;

        private string healableTag = "HealingObject";

        private void Start() 
        {      
            crosshair.color = Color.clear; // Stops the crosshair from appearing when it shouldn't by making it invisible as the game starts.
        }

        private void Update() 
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskHeal.value; // Makes sure the player can't interact with non-interactable objects.

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(healableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<HealItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if(Input.GetKeyDown(needleUp))
                    {
                        raycastedObject.SyringeInteraction();
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
                crosshair.color = Color.white; // Makes the crosshair appear when it's over something it can itneract with.
            }
            else
            {
                crosshair.color = Color.clear; // Otherwise, makes the crosshair invisible.
                isCrosshairActive = false;
            }
        }
    }

}

