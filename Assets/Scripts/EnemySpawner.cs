using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // assign the enemy prefab in the inspector
    public Transform[] spawnPoints; // assign the spawn points in the inspector

    private void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}