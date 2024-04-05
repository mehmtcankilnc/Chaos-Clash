using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int numberOfEnemiesPerWave;
    public int increasePerWave;
    public float timeBetweenWaves;

    private Transform[] spawnPoints;
    private int waveCount = 0;
    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        StartNextWave();
    }
    private void StartNextWave()
    {
        waveCount++;
        StartCoroutine(SpawnWave());
    }
    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < numberOfEnemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        numberOfEnemiesPerWave += increasePerWave;
        StartNextWave();
    }
    private void SpawnEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];

        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
