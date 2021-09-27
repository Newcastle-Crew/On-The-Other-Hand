#region 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false; // A box that should be ticked if the object is the red door.
        [SerializeField] private bool blueDoor = false; // A box that should be ticked if the object is the blue door.

        [SerializeField] private bool redKey = false; // A box that should be ticked if the object is the red key.
        [SerializeField] private bool blueKey = false; // A box that should be ticked if the object is the blue key.

        [SerializeField] private KeyInventory _keyInventory = null;

        [Header ("Audio")]
        [SerializeField] private AudioSource itemPickupAudioSource = null; // A place for you to drag the 'pickup' audio source.
        [SerializeField] private float pickupDelay = 0; // Can delay the sound effect's beginning time.

        public bool Collected = false;

        private KeyDoorController doorObject;

        private void Start() 
        {
            if ( redDoor || blueDoor )
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if ( redDoor || blueDoor )
            {
                doorObject.PlayAnimation(); // If the player has the correct key and interacts with the door, it opens and plays the animation.
            }

            else if (redKey) // if the player interacts with the red key, it is added to their inventory.
            {
                _keyInventory.hasRedKey = true; // Sets the inventory's "has red key?" bool to true.
                gameObject.SetActive(false); // Removes the red key from the game.
                itemPickupAudioSource.PlayDelayed(pickupDelay); // Plays the 'opening' sound effect after a delay.
            }

            else if (blueKey) // if the player interacts with the blue key, it is added to their inventory.
            {
                _keyInventory.hasBlueKey = true; // Sets the inventory's "has blue key?" bool to true.
                gameObject.SetActive(false); // removes the blue key from the game.
                itemPickupAudioSource.PlayDelayed(pickupDelay); // Plays the 'opening' sound effect after a delay.
            }
        } 
    }

}

