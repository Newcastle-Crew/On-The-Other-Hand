using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        public bool doorOpen = false;
        public bool doorClosing = false;
        public bool doorRattle = false;

        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";

        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool blueDoor = false;
        [SerializeField] private bool boxDoor = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1; // Gives a 1-second timer between showing the "LOCKED" message.
        [SerializeField] private bool pauseInteraction = false; // Stops the player from spamming interaction.

        [SerializeField] private AudioSource doorOpeningSound;
        [SerializeField] private AudioSource doorClosingSound;
        [SerializeField] private AudioSource doorLockedSound;

        private void Awake() 
        {
            doorAnim = gameObject.GetComponent<Animator>();
            doorOpeningSound = GetComponent<AudioSource>();
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

            else if (boxDoor == true && _keyInventory.hasRedKey)
            {
                DestroyDoor();
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
                    doorOpeningSound.Play(); // Plays the 'creaking door' sound effect.
                    StartCoroutine(PauseDoorInteraction()); // Stops the player from spamming the door.
                }

                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    doorClosing = true;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
        }

        public void DestroyDoor()
        {
            gameObject.SetActive(false);
        }

        IEnumerator ShowDoorLocked()
        {
            doorRattle = true;
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }   
}

