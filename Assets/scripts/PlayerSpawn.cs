using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Set initial spawn position for the first scene
        UpdatePlayerPosition();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Called when the scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdatePlayerPosition();
    }

    // Update the player's position based on the spawn point
    private void UpdatePlayerPosition()
    {
        if (SpawnManager.Instance != null)
        {
            Debug.Log($"Spawning player at: {SpawnManager.Instance.spawnPoint}");
            transform.position = SpawnManager.Instance.spawnPoint;
        }
        else
        {
            Debug.LogWarning("SpawnManager.Instance is null. Cannot set player spawn position.");
        }
    }
}
