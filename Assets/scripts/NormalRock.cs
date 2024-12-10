using UnityEngine;
using System.Collections;

public class NormalRock : MonoBehaviour
{
    [Header("Health Pickup Settings")]
    public GameObject healthPickupPrefab; // Prefab for the health pickup
    public float spawnChance = 0.5f;      // 50% chance to spawn the health pickup

    [Header("Audio Settings")]
    public AudioClip destroySound;       // Sound to play when the rock is destroyed

    private int hitCount = 0;
    private bool canTakeHit = true; // Cooldown flag
    public float hitCooldown = 1f; // Cooldown duration in seconds

    public void TakeHit()
    {
        if (!canTakeHit) return; // Ignore hits during cooldown

        hitCount++;

        if (hitCount == 1)
        {
            PlayDestroySound();   // Play destruction sound
            SpawnHealthPickup();  // Attempt to spawn the health pickup
            Destroy(gameObject);  // Destroy the rock
        }

        StartCoroutine(HitCooldown());
    }

    private IEnumerator HitCooldown()
    {
        canTakeHit = false; // Disable further hits
        yield return new WaitForSeconds(hitCooldown); // Wait for cooldown duration
        canTakeHit = true; // Enable hits again
    }

    private void SpawnHealthPickup()
    {
        if (healthPickupPrefab != null && Random.value < spawnChance)
        {
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
        }
    }

    private void PlayDestroySound()
    {
        if (destroySound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(destroySound); // Call the AudioManager to play sound
        }
        else
        {
            Debug.LogWarning("AudioManager or destroySound is missing!");
        }
    }
}
