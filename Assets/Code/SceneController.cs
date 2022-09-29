using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public bool paused;
    public static SceneController instance;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetPause(false);
    }

    public void LoadScene(string sceneName) {
        SetPause(sceneName == "Menu");
        SceneManager.LoadScene(sceneName);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main") //If the player presses the escape key
        {
            TogglePause(); //Call the TogglePause function in the SceneController
        }
    }
    public void HandleExit() {
        Application.Quit();
    }
    public void SetPause(bool pause) {
        paused = pause;
        Time.timeScale = pause ? 0 : 1;
        Cursor.visible = paused; 
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void SetPauseMenu(bool pauseIn) {
        SetPause(pauseIn);
        pauseMenu.SetActive(paused);
    }
    public void TogglePause() {
        SetPause(!paused);
    }
}
