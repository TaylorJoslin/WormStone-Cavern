using UnityEngine;
using System.Collections;

public class RockHole : MonoBehaviour
{
    public Sprite smallRockSprite, smallerRockSprite, hole;

    public GameObject player, spawnpoint;

    public Animator animator;

    private int hitCount = 0;
    private bool canTakeHit = true; // Cooldown flag
    public float hitCooldown = 1f; // Cooldown duration in seconds

    // Reference to the sound clip to be played when the rock is hit
    public AudioClip hitSound;

    public void TakeHit()
    {
        if (!canTakeHit) return; // Ignore hits during cooldown

        hitCount++;

        if (hitCount == 1)
        {
            GetComponent<SpriteRenderer>().sprite = hole;
            transform.localScale = Vector3.one;

            // Set up the collider for the hole
            CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
            circleCollider2D.radius = 0.35f;

            PlayHitSound();  // Play the sound when the rock becomes a hole
        }

        StartCoroutine(HitCooldown()); // Start cooldown
    }

    private IEnumerator HitCooldown()
    {
        canTakeHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canTakeHit = true;
    }

    // Method to play the hit sound using the AudioManager
    private void PlayHitSound()
    {
        if (hitSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(hitSound); // Play sound via AudioManager
        }
        else
        {
            Debug.LogWarning("Hit sound or AudioManager is missing!");
        }
    }
}
