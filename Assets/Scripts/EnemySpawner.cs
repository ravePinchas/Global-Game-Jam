using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Enemy enemy;
    public Transform[] spawnPoints;
    public float startSpawnTime = 0.0f;
    public float startSpawnRate = 1.0f;
    public float timeToReachMaxRateBeforeRoundEnd = 30.0f; // 30 seconds
    public float endSpawnRate = 0.2f;
    float currSpawnRate;
    float spawnCountdown;
    GameTime timer;

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
        currSpawnRate = startSpawnRate;
        spawnCountdown = -1.0f;
        timer = GameTime.GetTimer();
    }

    private void Update()
    {
        if (startSpawnTime > timer.stageTimer)
        {
            return;
        }

        if (spawnCountdown <= 0.0f)
        {
            SpawnEnemy();
            spawnCountdown = currSpawnRate;
            currSpawnRate = Mathf.Lerp(startSpawnRate, endSpawnRate, Mathf.InverseLerp(0.0f, timer.stageEndTimer - timeToReachMaxRateBeforeRoundEnd, timer.stageTimer));
        }

        spawnCountdown -= Time.deltaTime;
    }
}
