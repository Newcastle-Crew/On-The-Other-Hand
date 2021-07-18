using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1; // Gives a 1-second timer between showing the "LOCKED" message.
        [SerializeField] private bool pauseInteraction = false; // Stops the player from spamming interaction.

        private void Awake() 
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true; // Pauses interaction
            yield return new WaitForSeconds(waitTimer); // Waits a second
            pauseInteraction = false; // Unpauses interaction
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasRedkey) // If the player has the red key...
            {
                if(!doorOpen && !pauseInteraction) // If the door isn't open and interaction isn't paused...
                {
                    doorAnim.Play(openAnimationName, 0, 0.0f);
                    doorOpen = true; // Opens the door.
                    StartCoroutine(PauseDoorInteraction()); // Stops the player from spamming the door.
                }

                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }

            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }   
}

