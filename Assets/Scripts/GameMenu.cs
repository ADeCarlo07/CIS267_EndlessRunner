using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI firstPlace;
    public TextMeshProUGUI secondPlace;
    public TextMeshProUGUI thirdPlace;
    public TextMeshProUGUI fourthPlace;
    public TextMeshProUGUI fifthPlace;

    public GameObject highscorePanel;
    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        Application.Quit();

        
    }

    public void loadHighscores()
    {
        highscorePanel.SetActive(true);
    }

    public void exitHighschores()
    {
        highscorePanel.SetActive(false);
    }
    public void resetScores()
    {
        PlayerPrefs.DeleteAll();

        firstPlace.text = PlayerPrefs.GetFloat("highscore_1").ToString("0");
        secondPlace.text = PlayerPrefs.GetFloat("highscore_2").ToString("0");
        thirdPlace.text = PlayerPrefs.GetFloat("highscore_3").ToString("0");
        fourthPlace.text = PlayerPrefs.GetFloat("highscore_4").ToString("0");
        fifthPlace.text = PlayerPrefs.GetFloat("highscore_5").ToString("0");

    } 

}
