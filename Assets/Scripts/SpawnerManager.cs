using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;

    public List<EnemyBase> enemyBases = new List<EnemyBase>();
    public int maxEnemy = 20;

    [SerializeField] private GameObject[] enemyObject;
    [SerializeField] private Transform enemySpawnPoint;

    private bool isSpawning;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (enemyBases.Count < maxEnemy && !isSpawning)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        isSpawning = true;

        yield return new WaitForSeconds(1f);

        Instantiate(
            enemyObject[Random.Range(0, enemyObject.Length)],
            enemySpawnPoint.position,
            Quaternion.identity
        );

        isSpawning = false;
    }

    public void AddEnemy(EnemyBase enemy)
    {
        if (!enemyBases.Contains(enemy))
            enemyBases.Add(enemy);
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        if (enemyBases.Contains(enemy))
            enemyBases.Remove(enemy);
    }
}
