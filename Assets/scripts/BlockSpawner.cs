using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject blockObstaclePrefab;

    Queue<GameObject> blocks = new Queue<GameObject>();
    int initialWavesCount = 3;
    int blockDistance = 50;

    float blockPassGap = 10.0f;
    public int blocksPerWave = 3;
    public float timeBetweenWaves = 2f;
	private float timeToSpawn = 5f;
    

    void Awake() {
        CleanBlocksQueue();
        StartCoroutine("CleanInvisibleBlocks");
        for(int i = 0; i < initialWavesCount; i++) {
            CreateMultipleBlocks(blocksPerWave, i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSpawn) {
            CreateMultipleBlocks(blocksPerWave, 1);
            timeToSpawn += timeBetweenWaves;
        }
    }
    
    IEnumerator CleanInvisibleBlocks () {
        while (true) {
            Debug.Log("cleaning invisible blocks " + blocks.Count);
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

    void CleanBlocksQueue() {
        while (blocks.Count > 0) {
            Destroy(blocks.Dequeue());
        }
    }

    void CreateMultipleBlocks(int count, int zWeight) {
        for (int i = 0; i < count; i++) {
            CreateNewBlock((i+1) * zWeight * blockDistance);
        }
    }

    void CreateNewBlock(float distanceFromPlayer) {
        float newX = Random.Range(-6.0f, 6.0f);
        float newY = (float) Random.Range(0.0f, 2.0f);
        float newZ = (float) (player.position.z + distanceFromPlayer);
        Vector3 blockPos = new Vector3(newX, newY, newZ) + (Random.insideUnitSphere * 0.2f);
        GameObject newBlock = Instantiate(blockObstaclePrefab, blockPos, Random.rotation);
        blocks.Enqueue(newBlock);
    }
}
