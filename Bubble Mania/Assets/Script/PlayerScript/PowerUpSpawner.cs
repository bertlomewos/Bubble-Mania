using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private PowerUp[] powerUpPrefabs; 
    [SerializeField] private BoxCollider2D spawnArea; 
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private float spawnCheckRadius = 0.8f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 2f, spawnInterval); 
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefabs.Length == 0 || spawnArea == null) return;

        Vector2 randomPosition;

        for (int i = 0; i < 10; i++)
        {
            randomPosition = GetRandomPointInBounds(spawnArea.bounds);

            if (!IsPositionOnGround(randomPosition))
            {
                int randomPowerUpIndex = Random.Range(0, powerUpPrefabs.Length);

                Instantiate(powerUpPrefabs[randomPowerUpIndex], randomPosition, Quaternion.identity);
                return;
            }
        }
        Debug.LogWarning("Failed to spawn power up after 10 attempts.");
    }

    private Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }

    private bool IsPositionOnGround(Vector2 position)
    {
        return Physics2D.OverlapCircle(position, spawnCheckRadius, groundLayer) != null;
    }

    private void OnDrawGizmos()
    {
        if (spawnArea != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }
}
