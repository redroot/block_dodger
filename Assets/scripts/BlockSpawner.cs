using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject blockObstaclePrefab;

    Queue<GameObject> blocks = new Queue<GameObject>();
    int initialWavesCount = 15;
    
    int waveCount = 0;
    int blockDistance = 60;

    float blockPassGap = 10.0f;
    public int blocksPerWave = 4;
    public float timeBetweenWaves = 2f;
	private float timeToSpawn = 4f;
    

    void Awake() {
        CleanBlocksQueue();
        for(int i = 0; i < initialWavesCount; i++) {
            CreateBlockWave(blocksPerWave);
        }
        StartCoroutine("CleanInvisibleBlocks");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > timeToSpawn) {
            CreateBlockWave(blocksPerWave);
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

    void CreateBlockWave(int count) {
        waveCount++;
        for (int i = 0; i < count; i++) {
            CreateNewBlock(waveCount * blockDistance);
        }
    }

    void CreateNewBlock(float zDistance) {
        float newX = Random.Range(-6.0f, 6.0f);
        float newY = (float) Random.Range(0.0f, 2.0f);
        float newZ = (float) zDistance + Random.Range(-20.0f, 20.0f);
        Vector3 blockPos = new Vector3(newX, newY, newZ) + (Random.insideUnitSphere * 0.2f);
        GameObject newBlock = Instantiate(blockObstaclePrefab, blockPos, Random.rotation);
        newBlock.transform.localScale = NewBlockLocalScale();
        blocks.Enqueue(newBlock);
    }

    Vector3 NewBlockLocalScale() {
        return new Vector3(
            Random.Range(0.8f, 1.2f), 
            Random.Range(0.8f, 1.2f), 
            Random.Range(0.8f, 1.2f)
        );
    }
}
