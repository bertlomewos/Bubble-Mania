using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private PowerUp[] powerUpPrefabs; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private float spawnInterval = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 2f, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        int randomPowerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(powerUpPrefabs[randomPowerUpIndex],
                    spawnPoints[randomSpawnPointIndex].position,
                    Quaternion.identity);
    }
}
