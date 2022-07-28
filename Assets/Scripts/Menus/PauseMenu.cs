#region 'Using' information
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private GameObject[] subMenus = new GameObject[0];


    void Update()
    {
        if (CanPause() && Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            { Resume(); }
            else
            { Pause(); }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
    }

    public void BackToMenu() // Loads the menu.
    { 
        SceneManager.LoadScene("MainMenu");
        Resume();
    } 

    private bool CanPause()
    {
        foreach(GameObject menu in subMenus)
        {
            if(menu.activeInHierarchy) return false;
        }

        return true;
    }
}