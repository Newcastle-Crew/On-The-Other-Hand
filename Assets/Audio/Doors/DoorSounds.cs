using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class DoorSounds : MonoBehaviour
{
    #region Checks for the door being opened, closed, or already locked.
    public KeyDoorController doorOpening;
    public KeyDoorController doorClosing;
    public KeyDoorController doorLocked;
    #endregion

    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    public AudioClip lockedDoorSound;

    AudioSource myAudioSource1;
    AudioSource myAudioSource2;
    AudioSource myAudioSource3;
    
    void Start() // Start is called before the first frame update
    {
        myAudioSource1 = AddAudio (false, false, 1f);
        myAudioSource2 = AddAudio (false, false, 1f);
        myAudioSource3 = AddAudio (false,false, 1f);
        StartPlayingSounds();
    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = openDoorSound;
        newAudio.clip = closeDoorSound;
        newAudio.clip = lockedDoorSound;

        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    void StartPlayingSounds()
    {
        if (doorOpening.doorOpen)
        {
            myAudioSource1.clip = openDoorSound; // Plays the pained sound effect, but only for syringe 1 & 2.
            myAudioSource1.Play();
        }

        else if (doorOpening.doorClosing)
        {
            myAudioSource2.clip = closeDoorSound; // Plays the dying sound effect, but only for syringe 3.
            myAudioSource2.Play();
        }

        else if (doorOpening.doorRattle)
        {
            myAudioSource2.clip = closeDoorSound; // Plays the dying sound effect, but only for syringe 3.
            myAudioSource2.Play();
        }

        doorOpening.doorOpen = false; // Stops the sound effect from repeating.
        doorClosing.doorClosing = false; // Stops the sound effect from repeating.
        doorLocked.doorRattle = false; // Stops the sound effect from repeating.
    }
    
    void Update() // Update is called once per frame
    {
        if (doorOpening.doorOpen || doorClosing.doorClosing || doorLocked.doorRattle)
        {
            StartPlayingSounds();
        }
    }
}

}
