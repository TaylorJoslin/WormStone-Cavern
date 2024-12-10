using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    // Reference to the pickup sound effect
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Access the HealthManager and call the HealHP method
            HealthManager healthManager = collision.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.HealHP();
            }

            // Play the pickup sound
            PlayPickupSound();

            // Destroy the health pickup object
            Destroy(gameObject);
        }
    }

    // Play the pickup sound when the player collects the health pickup
    private void PlayPickupSound()
    {
        if (pickupSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(pickupSound);
        }
        else
        {
            Debug.LogWarning("Pickup sound or AudioManager is missing!");
        }
    }
}
