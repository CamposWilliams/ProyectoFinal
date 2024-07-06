using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 5f; 
    public Vector2 spawnArea = new Vector2(10f, 10f); 
    public int maxEnemies = 10; 

    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentEnemyCount < maxEnemies)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    0,
                    Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
                ) + transform.position;

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                currentEnemyCount++;
            }
        }
    }

    public void EnemyDefeated()
    {
        currentEnemyCount--;
    }
}
