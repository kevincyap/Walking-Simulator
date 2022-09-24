using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public static bool paused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        SetPause(true);
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
    public void SetPause(bool pauseIn) {
        paused = pauseIn;
        Time.timeScale = paused ? 0 : 1;
        Cursor.visible = paused; 
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        pauseMenu.SetActive(paused);
    }
    public void TogglePause() {
        SetPause(!paused);
    }
}
