using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class VictimSounds : MonoBehaviour
{
    #region Checks for syringes 1-3 being taken.
    public HealItemController takensyringe1;
    public HealItemController takensyringe2;
    public HealItemController takensyringe3;
    #endregion

    public AudioClip painGrunt;
    public AudioClip deathGrunt;

    AudioSource myAudioSource1;
    AudioSource myAudioSource2;
    
    void Start() // Start is called before the first frame update
    {
        myAudioSource1 = AddAudio (false, false, 1f);
        myAudioSource2 = AddAudio (false, false, 1f);
        StartPlayingSounds();
    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = painGrunt;
        newAudio.clip = deathGrunt;

        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    void StartPlayingSounds()
    {
        if (takensyringe1.victimPain || takensyringe2.victimPain)
        {
            myAudioSource1.clip = painGrunt; // Plays the pained sound effect, but only for syringe 1 & 2.
            myAudioSource1.Play();
        }

        else if (takensyringe3.victimDie)
        {
            myAudioSource2.clip = deathGrunt; // Plays the dying sound effect, but only for syringe 3.
            myAudioSource2.Play();
        }

        takensyringe1.victimPain = false; // Stops the sound effect from repeating.
        takensyringe2.victimPain = false; // Stops the sound effect from repeating.
        takensyringe3.victimDie = false; // Stops the sound effect from repeating.
    }
    
    void Update() // Update is called once per frame
    {
        if (takensyringe1.victimPain || takensyringe2.victimPain || takensyringe3.victimDie)
        {
            StartPlayingSounds();
        }
    }
}

}
