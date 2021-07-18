using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start() 
        {
            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

        }

        public void ObjectInteraction()
        {
            if (redDoor)
            {
                doorObject.PlayAnimation(); // If the player has the key and interacts with the door, it opens and plays the animation.
            }

            else if (redKey) // if the player interacts with the key, it is added to their inventory.
            {
                _keyInventory.hasRedkey = true;
                gameObject.SetActive(false);
            }
        }     
    }

}

