using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText = null;
    int score = 0;

    public int Score{
        get
        {
            return score;
        }
        set
        {
            score = value;
            if(scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        Score = score;
    }
}
