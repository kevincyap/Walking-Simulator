using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public bool paused;
    public GameObject startMenu;
    public GameObject pauseMenu;
    private bool showStart; 
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        TogglePause();
    }

    public void handleStart() {
        startMenu.SetActive(false);
        TogglePause();
    }
    
    public void handleExit() {
        Application.Quit();
    }

    public void TogglePause() {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        Cursor.visible = paused; 
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        pauseMenu.SetActive(paused);
    }
}
