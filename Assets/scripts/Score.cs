using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public ScoreManager scoreManager;
    public Text scoreText;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreManager.score.ToString("0");
    }
}
