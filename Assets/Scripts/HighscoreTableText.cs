using TMPro;
using UnityEngine;

public class HighscoreTableText : MonoBehaviour
{
    public TextMeshProUGUI firstPlace;
    public TextMeshProUGUI secondPlace;
    public TextMeshProUGUI thirdPlace;
    public TextMeshProUGUI fourthPlace;
    public TextMeshProUGUI fifthPlace;

    private bool duplicateFound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPlace.text = PlayerPrefs.GetFloat("highscore_1").ToString();
        secondPlace.text = PlayerPrefs.GetFloat("highscore_2").ToString();
        thirdPlace.text = PlayerPrefs.GetFloat("highscore_3").ToString();
        fourthPlace.text = PlayerPrefs.GetFloat("highscore_4").ToString();
        fifthPlace.text = PlayerPrefs.GetFloat("highscore_5").ToString();


       
    }
    
}
