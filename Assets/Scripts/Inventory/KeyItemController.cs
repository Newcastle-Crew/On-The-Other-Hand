using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool blueDoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] private bool blueKey = false;
        [SerializeField] private KeyInventory _keyInventory = null;

        public bool Collected = false;

        private KeyDoorController doorObject;

        private void Start() 
        {
            if (redDoor || blueDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (redDoor || blueDoor)
            {
                doorObject.PlayAnimation(); // If the player has the key and interacts with the door, it opens and plays the animation.
            }

            else if (redKey) // if the player interacts with the key, it is added to their inventory.
            {
                StartCoroutine(MakeaSwoosh());
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }

            else if (blueKey)
            {
                StartCoroutine(MakeaSwoosh());
                _keyInventory.hasBlueKey = true;
                gameObject.SetActive(false);
            }
        } 

        private IEnumerator MakeaSwoosh()
        {
            yield return Collected = true;
            Collected = true;
        }
    }

}

