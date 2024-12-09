using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Access the HealthManager and call the TakeDamage method
            HealthManager healthManager = collision.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.HealHP();
            }

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
