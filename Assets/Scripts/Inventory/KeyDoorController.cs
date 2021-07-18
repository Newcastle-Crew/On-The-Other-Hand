using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [SerializeField] private string openAnimationName = "LeftDoorOpen OR DoorOpen";
        [SerializeField] private string closeAnimationName = "LeftDoorClose OR DoorClose";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1; // Gives a 1-second timer between showing the "LOCKED" message.
        [SerializeField] private bool pauseInteraction = false; // When true, stops the player from spamming interaction with doors.

        private void Awake() 
        {
            doorAnim = gameObject.GetComponent<Animator>(); // Will animate doors.
        }

        private IEnumerator PauseDoorInteraction() // Stops the player from spamming interaction with doors.
        {
            pauseInteraction = true; // Pauses interaction
            yield return new WaitForSeconds(waitTimer); // Waits a second
            pauseInteraction = false; // Unpauses interaction
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasRedKey) // If the player has the RED key...
            {
                DoorOpenRed();
            }

            if (_keyInventory.hasBlueKey) // If the player has the BLUE key...
            {
                DoorOpenBlue();
            }

            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void DoorOpenRed()
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

        void DoorOpenBlue()
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

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }   
}

