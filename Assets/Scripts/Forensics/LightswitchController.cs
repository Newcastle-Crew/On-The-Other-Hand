#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
#endregion

public class LightswitchController : MonoBehaviour
{
    [SerializeField] private bool isLightOn;
    [SerializeField] private UnityEvent lightOnEvent;
    [SerializeField] private UnityEvent lightOffEvent;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material lightOnMaterial;
    [SerializeField] private Material lightOffMaterial;

    private void Start()
    {
        // Set initial material based on the starting state
        UpdateMaterial();
    }

    public void InteractSwitch()
    {
        isLightOn = !isLightOn; // Toggle the light state

        if (isLightOn)
        {
            lightOnEvent.Invoke();
        }
        else
        {
            lightOffEvent.Invoke();
        }

        UpdateMaterial(); // Update the material based on the new state
    }


    private void UpdateMaterial()
    {
        // Assign the appropriate material based on the light state
        meshRenderer.material = isLightOn ? lightOnMaterial : lightOffMaterial;
    }
}
