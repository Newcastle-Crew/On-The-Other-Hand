using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class VictimSounds : MonoBehaviour
{
    [SerializeField] private AudioSource painGrunt;
    [SerializeField] private AudioSource deathGrunt;

    public HealItemController makeNoise;
    public HealItemController makeNoise2;
    public HealItemController makeNoise3;


    
    void Start() // Start is called before the first frame update
    {
        painGrunt = GetComponent<AudioSource>();
        deathGrunt = GetComponent<AudioSource>();
    }

    
    void Update() // Update is called once per frame
    {
        if (makeNoise.victimPain || makeNoise2.victimPain || makeNoise3.victimPain)
        {
            MakeSomeNoise();
        }
    }

    void MakeSomeNoise()
    {
            painGrunt.PlayOneShot(painGrunt.clip); // Plays the 'grunt of pain' sound effect.
            makeNoise.victimPain = false;
            makeNoise2.victimPain = false;
            makeNoise3.victimPain = false;
    }
}

}
