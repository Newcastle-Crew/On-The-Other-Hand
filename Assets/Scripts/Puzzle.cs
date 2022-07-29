using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    protected PlayerHealth playerHealth;
    protected FirstPersonAIO playerController;


    protected virtual void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerController = FindObjectOfType<FirstPersonAIO>();
    }

    protected virtual void OnEnable()
    {
        playerHealth.SetBleeding(false);
        playerController.puzzleOpen = true;
    }

    protected virtual void OnDisable()
    {
        playerHealth.SetBleeding(true);
        playerController.puzzleOpen = false;
    }
}
