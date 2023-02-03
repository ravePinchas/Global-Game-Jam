using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Enemy enemy;
    public Transform[] spawnPoints;
    
    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemyBehavior enemyBehaviour = newEnemy.GetComponent<EnemyBehavior>();
        enemyBehaviour.enemyPrefab = enemy;

        enemyBehaviour.enemyInstance = Instantiate(enemyBehaviour.enemyPrefab);
    }


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }
}
