#region 'Using' information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class MainMenu : MonoBehaviour
{
    /*
        Click on the buttons, then add one of the two methods below via the 'OnClicked' part that handles events in the inspector.         
    */

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    { SceneManager.LoadScene("TestScene"); } // Loads the game.

    public void QuitGame()
    {
        Debug.Log("QUIT!"); // Prints 'QUIT' if testing this in the editor.
        Application.Quit(); // Closes the game.
    }
}