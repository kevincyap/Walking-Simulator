using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Game Over
 * Source: Introduction to Game Development (E25: stealth game 3/3), Sebastian Lague
 * https://www.youtube.com/watch?v=MOLg3W0HeLs, 2017, April 30th
 */

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
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (gameWin)
        {
            if (Input.GetKeyDown("space"))
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
