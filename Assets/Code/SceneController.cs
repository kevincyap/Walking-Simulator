using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public bool paused;
    public bool pauseMenuOpen;
    public static SceneController instance;
    public GameObject pauseMenu;
    public GameObject Objectives;
    public GameObject inventory;
    public GameObject reticle;
    public bool isMainMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetPause(isMainMenu);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMainMenu) //If the player presses the escape key
        {
            SetPauseMenu(!paused); //Call the TogglePause function in the SceneController
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
        if (pauseMenu) {
            pauseMenu.SetActive(paused);
        }
        if (Objectives) {
            Objectives.SetActive(!paused);
        }
        if (reticle) {
            reticle.SetActive(!paused);
        }
        if (paused) {
            if (inventory) {
                inventory.SetActive(!paused);
            }
        }
    }
}
