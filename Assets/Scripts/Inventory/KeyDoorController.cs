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

        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool blueDoor = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1; // Gives a 1-second timer between showing the "LOCKED" message.
        [SerializeField] private bool pauseInteraction = false; // Stops the player from spamming interaction.

        [SerializeField] private AudioSource creakopen;
        [SerializeField] private AudioSource itislocked;
        [SerializeField] private AudioSource closing;

        private void Awake() 
        {
            doorAnim = gameObject.GetComponent<Animator>();
            creakopen = GetComponent<AudioSource>();
            itislocked = GetComponent<AudioSource>();
            closing = GetComponent<AudioSource>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true; // Pauses interaction
            yield return new WaitForSeconds(waitTimer); // Waits a second
            pauseInteraction = false; // Unpauses interaction
        }

        public void PlayAnimation()
        {
            if (redDoor == true && _keyInventory.hasRedKey) // If the player has the RED key...
            {
                OpenDoor(); // Open the door.
            }

            else if (blueDoor == true && _keyInventory.hasBlueKey) // If the player has the BLUE key...
            {
                OpenDoor(); // Open the door.
            }

            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void OpenDoor()
        {
            {
                if(!doorOpen && !pauseInteraction) // If the door isn't open and interaction isn't paused...
                {
                    doorAnim.Play(openAnimationName, 0, 0.0f);
                    doorOpen = true; // Opens the door.
                    creakopen.Play(); // Plays the 'creaking door' sound effect.
                    StartCoroutine(PauseDoorInteraction()); // Stops the player from spamming the door.
                }

                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
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

