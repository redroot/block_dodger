using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    public Transform player;
    public Light directionalLight;

    public BlockSpawner blockSpawner;

    public CanvasGroup stageOneLabel;
    public CanvasGroup stageTwoLabel;
    public CanvasGroup stageThreeLabel;
    public CanvasGroup stageFourLabel;

    float stageTwoStartDistance = 500;
    float stageThreeStartDistance = 1100;
    float stageFourStartDistance = 1900; // 1000 apart

    Color stageTwoColour = new Color32(191, 231, 248, 255);
    Color stageThreeColour = new Color32(255, 203, 158, 255);

    Color stageFourColour = new Color32(248, 95, 95, 255);

    public bool stageOneReached = true;
    public bool stageTwoReached = false;
    public bool stageThreeReached = false;
    public bool stageFourReached = false;
    

    public enum Stage {
        StageOne,
        StageTwo,
        StageThree,
        StageFour
    }

    public Stage currentStage = Stage.StageOne;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if (player.position.z > stageFourStartDistance) {
           stageFourReached = true;
           currentStage = Stage.StageFour;
           stageFourLabel.alpha = 1.0f;
           stageThreeLabel.alpha = 0.5f;
           directionalLight.color = stageFourColour;
           blockSpawner.blocksPerWave = 12;
           // interpolate colour with a co routine here or invoke a function;
       } else if (player.position.z > stageThreeStartDistance) {
           stageThreeReached = true;
           currentStage = Stage.StageThree;
           stageThreeLabel.alpha = 1.0f;
           stageTwoLabel.alpha = 0.5f;
           directionalLight.color = stageThreeColour;
           blockSpawner.blocksPerWave = 8;
       } else if (player.position.z > stageTwoStartDistance) {
           stageTwoReached = true;
           currentStage = Stage.StageTwo;
           stageTwoLabel.alpha = 1.0f;
           stageOneLabel.alpha = 0.5f;
           directionalLight.color = stageTwoColour;
           blockSpawner.blocksPerWave = 6;
       }
    }
}
