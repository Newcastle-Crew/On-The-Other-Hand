#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#endregion

public class LightswitchController : MonoBehaviour
{
    [SerializeField] private bool isLightOn;
    [SerializeField] private UnityEvent lightOnEvent;
    [SerializeField] private UnityEvent lightOffEvent;

    public void InteractSwitch()
    {
        if(!isLightOn)
        {
            isLightOn = true;
            lightOnEvent.Invoke();
        }
        else
        {
            isLightOn = false;
            lightOffEvent.Invoke();
        }

    }
}
