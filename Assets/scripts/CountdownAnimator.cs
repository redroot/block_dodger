using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownAnimator : MonoBehaviour
{
    public Text countdownText;
    public GameManager gameManager;
    

    void Awake() {

    }
    void Update() {
        if (Time.timeSinceLevelLoad > 3.0f) {
            // next scene
            gameManager.GoToGameScene();
        } else if (Time.timeSinceLevelLoad > 2.0f) {
            countdownText.text = "1";
            countdownText.color = fadingGrayColor(2.0f, Time.timeSinceLevelLoad);
        } else if (Time.timeSinceLevelLoad > 1.0f) {
            countdownText.text = "2";
            countdownText.color = fadingGrayColor(1.0f, Time.timeSinceLevelLoad);
        } else {
            countdownText.color = fadingGrayColor(0.0f, Time.timeSinceLevelLoad);
        }
    }

    Color fadingGrayColor(float basis, float now) {
       float alpha = (basis - now) * 255f;
       return new Color32(60, 60, 60, (byte) alpha);
    }
}
