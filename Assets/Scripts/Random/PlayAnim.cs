#region 'Using' info
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class PlayAnim : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private string doorOpen = "doorOpen";

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            myDoor.Play("doorOpen, 0, 0.0f");
        }
    }
}
