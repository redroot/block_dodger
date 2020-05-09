using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public GameManager gameManager;
    public Text scoreText;
    public int score = 0;
    int lastPlayerPos = 0;
    FontStyle currentFontStyle = FontStyle.Normal;
    Color currentFontColor = Color.white;

    // Update is called once per frame
    void Update()
    {
        int currentPlayerPos = (int) player.position.z;
        int diff = currentPlayerPos - lastPlayerPos;
        lastPlayerPos = currentPlayerPos;

        if (gameManager.poweredUp) {
            score += (int) diff * 2;
            currentFontStyle = FontStyle.Bold;
            currentFontColor = Color.magenta;
        } else {
            score += (int) diff;
            currentFontStyle = FontStyle.Normal;
            currentFontColor = Color.white;
        }

        scoreText.text = score.ToString();
        scoreText.fontStyle = currentFontStyle;
        scoreText.color = currentFontColor;
    }
}
