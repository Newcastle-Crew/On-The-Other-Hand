using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HealItemController : MonoBehaviour
    {
        [SerializeField] private bool Syringe1 = false;
        [SerializeField] private bool Syringe2 = false;
        [SerializeField] private bool Syringe3 = false;

        public bool Healing = false; // Healing mechanic - tells the PlayerHealth class when to run the RestoreHealth method.
        private float waitTimer = 0.1f; // Gives a 0.5-second timer to stop the player from spamming syringes.
        public BoxCollider boxCollider;
        public MeshRenderer mesh;

        private static int SyringesUsed = 0;
        
        public void SyringeInteraction()
        {
            if (Syringe1 || Syringe2) // If the player has interacted with the syringe, run this code.
            {
                SyringesUsed++;
                boxCollider.enabled = false; // removes the ability to interact with the syringe
                mesh.enabled = false;
                StartCoroutine(HealMe()); // Starts a coroutine that heals the player.          
            }
            
            else if (Syringe3) // Can only use syringe 3 once 1 & 2 have been used.
            {
                if (SyringesUsed >= 2)
                {
                    StartCoroutine(HealMe());
                } 
            }
        }

        private IEnumerator HealMe()
    {
        Healing = true; // Starts healing the player
        yield return new WaitForSeconds(waitTimer); // Waits a second

        if (SyringesUsed >= 2)
        {
            Healing = false;
            gameObject.SetActive(false); // Destroys the needle object.
        }
        
    }

    }

}

