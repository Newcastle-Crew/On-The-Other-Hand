using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class PickupSound : MonoBehaviour
{
    [SerializeField] private AudioSource pickedUp;

    [SerializeField] public KeyItemController makeNoise;


    
    void Start() // Start is called before the first frame update
    {
        pickedUp = GetComponent<AudioSource>();
    }

    
    void Update() // Update is called once per frame
    {
        if (makeNoise.Collected)
        {
            MakeSomeNoise();
        }
    }

    void MakeSomeNoise()
    {
        pickedUp.PlayOneShot(pickedUp.clip); // Plays the 'swoosh' sound effect.
        makeNoise.Collected = false;
    }
}
}

