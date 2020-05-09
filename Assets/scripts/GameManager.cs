
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BlockSpawner blockSpawner;
    bool gameHasEnded = false;
    float gameRelaunchDelay = 2f;

    public bool poweredUp = false;

    public void Update () {
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

    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Invoke("Restart", gameRelaunchDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
