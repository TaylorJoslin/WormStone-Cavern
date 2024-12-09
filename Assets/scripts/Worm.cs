using UnityEngine;

public class Worm : MonoBehaviour
{
    public BossWormSpawn spawner;

    // Call this method when the worm dies
    public void Die()
    {
        Debug.Log("Worm destroyed. Informing spawner.");
        if (spawner != null)
        {
            spawner.OnWormDestroyed();
        }

        Destroy(gameObject); // Destroy the worm GameObject
        
    }
}
