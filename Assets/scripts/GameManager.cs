
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BlockSpawner blockSpawner;
    bool gameHasEnded = false;
    float gameRelaunchDelay = 2f;

    public bool poweredUp = false;

    public void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) == true) {
            Application.Quit();
        }
    }

    public void PowerUpPlayer () {
        poweredUp = true;
    }

    public void PowerDownPlayer () {
        poweredUp = false;
    }

    public void PowerUpPlayerFor(float seconds) {
        PowerUpPlayer();
        Invoke("PowerDownPlayer", seconds);
    }

    public void GoToGameScene () {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToTitleScene () {
        SceneManager.LoadScene("TitleScene");
    }

    public void GoToCountdownScene () {
        SceneManager.LoadScene("CountdownScene");
    }

    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Invoke("GoToCountdownScene", gameRelaunchDelay);
        }
    }
}
