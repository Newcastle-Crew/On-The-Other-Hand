#region 'Using information'
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#endregion

namespace KeySystem // Using the key system so that the hand shows up when looking at the table. Replace with one that will show the scalpel later.
{
    public class ShowUI : MonoBehaviour
  {
    
    #region Canvases
    [SerializeField] public Canvas dissectionCanvas; // Requires a canvas to work, so drag one into the inspector.
    [SerializeField] public Canvas regularCanvas; // Requires a canvas to work, so drag one into the inspector.
    #endregion

    public IInteractable Interactable { get; set; }

    private void Awake()
    {
        Cursor.visible = false; // Makes the cursor invisible when the game starts.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            ShowDissectionUI(); // Runs the 'ShowDissectionUI' void.
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            ExitPuzzle(); // Runs the 'ExitPuzzle' void.
        }
    }

    public void ShowDissectionUI() 
    {
        dissectionCanvas.gameObject.SetActive(true); // Shows the dissection puzzle.
        regularCanvas.gameObject.SetActive(false);
        Cursor.visible = true; // Makes the cursor visible.
        Cursor.lockState = CursorLockMode.None; // Allows the player to move their cursor around and click freely.
    }

    public void ExitPuzzle()
    {
        dissectionCanvas.gameObject.SetActive(false); // Hides the dissection puzzle.
        regularCanvas.gameObject.SetActive(true);
        Cursor.visible = false; // Makes the cursor invisible.
        Cursor.lockState = CursorLockMode.Locked; // Stops the player from moving their cursor around and clicking freely.
    }
  }
}
