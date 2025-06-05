using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    

    // Update is called once per frame
    void Update()
    {
        score.text = Scoring.totalScore.ToString("0");
    }

   
}
