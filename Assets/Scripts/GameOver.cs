using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public HighscoreTableManager HighscoreTableManager;
    private void Start()
    {
        HighscoreTableManager.HighScoreUpdate();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {

        Application.Quit();
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
