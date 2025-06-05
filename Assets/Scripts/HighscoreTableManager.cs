using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighscoreTableManager : MonoBehaviour
{
   

    

    public void HighScoreUpdate()
    {
        //Debug.Log("I have recieved scores");
        
        for (int i = 1; i <= 5; i++)
        {
            Scoring.totalScore = Mathf.RoundToInt(Scoring.totalScore);

            if (Scoring.totalScore == 0)
            {
                break;
            }

            //No duplicates allowed!!!! >:(
            if (Scoring.totalScore == PlayerPrefs.GetFloat("highscore_" + i))
            {
                break;
            }

            else if (Scoring.totalScore > PlayerPrefs.GetFloat("highscore_" + i))
            {
                for (int x = 5; x > i; x--)
                {
                    PlayerPrefs.SetFloat("highscore_" + x, PlayerPrefs.GetFloat("highscore_" + (x - 1)));
                }
                PlayerPrefs.SetFloat("highscore_" + i, Scoring.totalScore);

                break;
            }
        }





        //if (PlayerPrefs.HasKey("SavedHighscore"))
        //{
        //    if (Scoring.totalScore > PlayerPrefs.GetFloat("SavedHighscore"))
        //    {
        //        PlayerPrefs.SetFloat("Savedhighscore", Scoring.totalScore);
        //    }
        //}
        //else
        //{
        //    PlayerPrefs.SetFloat("Savedhighscore", Scoring.totalScore);
        //}

        //finalScore.text = PlayerPrefs.GetFloat("SavedHighscore").ToString();
    }
}
