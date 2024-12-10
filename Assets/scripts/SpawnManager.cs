using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    
    public static SpawnManager Instance;
    public Vector3 spawnPoint = Vector3.zero; // Local spawn point for the current scene

    void Awake()
    {
        // Ensure only one instance of SpawnManager exists
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes

        // Register to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the spawn point for the new scene (or set it to a default value)
        UpdateSpawnPointForScene(scene);
    }

    // Set the spawn point for the current scene
    void UpdateSpawnPointForScene(Scene scene)
    {
        // Example spawn points for different scenes (you can change these to fit your design)
        if (scene.name == "Level1")
        {
            spawnPoint = new Vector3(-0.477f, -0.496f, 0); // Example spawn point for Level1
            Debug.Log("Spawn point for Level1 set to: " + spawnPoint);
        }
        else if (scene.name == "Level2")
        {
            spawnPoint = new Vector3(-8, -1, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level3")
        {
            spawnPoint = new Vector3(-8.5f, -1, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level4")
        {
            spawnPoint = new Vector3(-0.4f, -0.5f, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level5")
        {
            spawnPoint = new Vector3(-0.4f, -0.5f, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level6")
        {
            spawnPoint = new Vector3(-0.4f, -0.5f, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level7")
        {
            spawnPoint = new Vector3(10f, 15f, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
        else if (scene.name == "Level8")
        {
            spawnPoint = new Vector3(10f, 15f, 0); // Example spawn point for Level2
            Debug.Log("Spawn point for Level2 set to: " + spawnPoint);
        }
    }

    // Reset the spawn point (useful if you want to reset between scenes)
    public void ClearSpawnPoint()
    {
        spawnPoint = Vector3.zero;
    }
}
