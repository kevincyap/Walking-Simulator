using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    bool gameOver;
    bool gameWin;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown("Space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (gameWin)
        {
            if (Input.GetKeyDown("Space"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void ShowGameWinUI()
    {
        OnGameOver(gameWinUI);
        gameWin = true;
    }

    public void ShowGameLoseUI()
    {
        OnGameOver(gameLoseUI);
        gameOver = true;
    }

    void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
    }
}
