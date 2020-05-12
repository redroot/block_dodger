using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject blockObstaclePrefab;

    Queue<GameObject> blocks = new Queue<GameObject>();
    int initialWavesCount = 6;
    int blockDistance = 70;

    float blockPassGap = 10.0f;
    public int blocksPerWave = 3;
    public float timeBetweenWaves = 2f;
	private float timeToSpawn = 4f;
    

    void Awake() {
        CleanBlocksQueue();
        for(int i = 0; i < initialWavesCount; i++) {
            CreateMultipleBlocks(blocksPerWave, i+1);
        }
        StartCoroutine("CleanInvisibleBlocks");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > timeToSpawn) {
            CreateMultipleBlocks(blocksPerWave, 1);
            timeToSpawn += timeBetweenWaves;
        }
    }
    
    IEnumerator CleanInvisibleBlocks () {
        while (true) {
            CleanBlocksQueueBehindPlayer();
            yield return new WaitForSeconds(2.0f);
        }
    }

    void CleanBlocksQueueBehindPlayer () {

        if (blocks.Count == 0) {
            return;
        }

        while (blocks.Peek().GetComponent<Transform>().position.z < (player.position.z - blockPassGap)) {
            Destroy(blocks.Dequeue());
        }
    }

    public void CleanBlocksQueue() {
        while (blocks.Count > 0) {
            Destroy(blocks.Dequeue());
        }
    }

    void CreateMultipleBlocks(int count, int zWeight) {
        for (int i = 0; i < count; i++) {
            CreateNewBlock(zWeight * blockDistance);
        }
    }

    void CreateNewBlock(float distanceFromPlayer) {
        float newX = Random.Range(-6.0f, 6.0f);
        float newY = (float) Random.Range(0.0f, 2.0f);
        float newZ = (float) (player.position.z + distanceFromPlayer) + (Random.Range(-30.0f, 30.0f));
        Vector3 blockPos = new Vector3(newX, newY, newZ) + (Random.insideUnitSphere * 0.2f);
        GameObject newBlock = Instantiate(blockObstaclePrefab, blockPos, Random.rotation);
        blocks.Enqueue(newBlock);
    }
}
