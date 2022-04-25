#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;

        public bool doorOpen = false;

        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";

        [SerializeField] private bool closetDoor = false;
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool blueDoor = false;
        [SerializeField] private bool yellowDoor = false;
        [SerializeField] private bool finalDoor = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null; // Keeps track of keys so that coloured doors correspond to coloured keys.

        [SerializeField] private int waitTimer = 1; // Gives a 1-second timer between showing the "LOCKED" message.
        [SerializeField] private bool pauseInteraction = false; // Stops the player from spamming interaction.

        [Header ("Audio")]
        [SerializeField] private AudioSource doorOpenAudioSource = null; // A place for you to drag the 'opening' audio source.
        [SerializeField] private float openDelay = 0; // Can delay the sound effect's beginning time.

        [SerializeField] private AudioSource doorCloseAudioSource = null; // A place for you to drag the 'closing' audio source.
        [SerializeField] private float closeDelay = 0.4f; // Can delay the sound effect's beginning time.


        private void Awake() 
        { doorAnim = gameObject.GetComponent<Animator>(); }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true; // Pauses interaction
            yield return new WaitForSeconds(waitTimer); // Waits a second
            pauseInteraction = false; // Unpauses interaction
        }

        public void PlayAnimation()
        {
            if (closetDoor == true)
            { OpenDoor(); }

            if (redDoor == true && _keyInventory.hasRedKey) // If the player has the RED key...
            { OpenDoor(); } // Open the door.

            else if (blueDoor == true && _keyInventory.hasBlueKey) // If the player has the BLUE key...
            { OpenDoor(); } // Open the door.

            else if (yellowDoor == true && _keyInventory.hasYellowKey) // If the player has the YELLOW key...
            { OpenDoor(); } // Open the door.

            else if (finalDoor == true && _keyInventory.hasFinger1 && _keyInventory.hasFinger2 && _keyInventory.hasFinger3 && _keyInventory.hasFinger4 && _keyInventory.hasFinger5) // If the player has ALL FINGERS...
            { OpenDoor(); } // Open the door.

            else
            { StartCoroutine(ShowDoorLocked()); }
        }

        void OpenDoor()
        {
            {
                if(!doorOpen && !pauseInteraction) // If the door isn't open and interaction isn't paused...
                {
                    doorAnim.Play(openAnimationName, 0, 0.0f);
                    doorOpen = true; // Opens the door.
                    StartCoroutine(PauseDoorInteraction()); // Stops the player from spamming the door.
                    doorOpenAudioSource.PlayDelayed(openDelay); // Plays the 'opening' sound effect after a delay.
                }

                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false; // Closes the door.
                    StartCoroutine(PauseDoorInteraction()); // Stops  the player from spamming the doors.
                    doorCloseAudioSource.PlayDelayed(closeDelay); // Plays the 'closing' sound effect after a delay.
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

