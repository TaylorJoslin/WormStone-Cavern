using System.Collections;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BossWormSpawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject wormPrefab; // Worm prefab to spawn
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); // Width and height of the square area
    public Vector2 spawnAreaOffset = Vector2.zero; // Offset of the spawn area relative to the boss
    public int maxWorms = 5; // Maximum number of worms that can exist at the same time
    public float spawnInterval = 3f; // Time between spawns

    [Header("Boss Settings")]
    public int bossHP = 100; // Boss's total HP
    public int hpLossPerWorm = 10; // Amount of HP the boss loses when a worm dies

    [Header("References")]
    public Transform boss; // Boss GameObject to spawn around

    private int currentWormCount = 0;

    void Start()
    {
        StartCoroutine(SpawnWorms());
    }

    private IEnumerator SpawnWorms()
    {
        while (true)
        {
            if (currentWormCount < maxWorms)
            {
                SpawnWorm();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnWorm()
    {
        // Calculate random position within the square area around the boss
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomY = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);

        // Apply offset to the spawn position
        Vector3 offsetPosition = new Vector3(spawnAreaOffset.x, spawnAreaOffset.y, 0);
        Vector3 spawnPosition = boss.position + offsetPosition + new Vector3(randomX, randomY, 0);

        // Spawn the worm
        GameObject worm = Instantiate(wormPrefab, spawnPosition, Quaternion.identity);

        // Assign a script to inform this spawner when the worm is destroyed
        Worm wormScript = worm.GetComponent<Worm>();
        if (wormScript != null)
        {
            wormScript.spawner = this;
        }

        currentWormCount++;
    }

    public void OnWormDestroyed()
    {
        currentWormCount--;
        DecreaseBossHP();
    }

    private void DecreaseBossHP()
    {
        bossHP -= hpLossPerWorm;
        Debug.Log($"Boss HP: {bossHP}");

        if (bossHP <= 0)
        {
            OnBossDefeated();
        }
    }

    private void OnBossDefeated()
    {
        Debug.Log("Boss defeated!");
        // Add additional logic for boss defeat (e.g., animations, game over screen)
    }

    // Draw the spawn area in the editor
    private void OnDrawGizmos()
    {
        if (boss != null)
        {
            Gizmos.color = Color.green;
            Vector3 center = boss.position + new Vector3(spawnAreaOffset.x, spawnAreaOffset.y, 0);
            Vector3 size = new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0);

            // Draw the spawn area as a wireframe cube
            Gizmos.DrawWireCube(center, size);
        }
    }
}
