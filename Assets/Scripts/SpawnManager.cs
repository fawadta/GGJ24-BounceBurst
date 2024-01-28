using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] SmallEnemyController smallEnemyPrefab;

    [SerializeField] int smallerEnemyCount;
    [SerializeField] int spawnRangeX;
    [SerializeField] int spawnRangeZ;
    public int enemyWaveCount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            enemyWaveCount++;
            SpawnEnemyWave();
        }

    }

    public void SpawnSmallerEnemies(Vector3 spawnPos)
    {
        for (int i = 0; i < smallerEnemyCount; i++)
        {
            Instantiate(smallEnemyPrefab, spawnPos, smallEnemyPrefab.transform.rotation);
        }
    }
    public void SpawnEnemyWave()
    {
        for (int i = 1; i <= enemyWaveCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }
}
