using UnityEngine;

public class RockWithHole : MonoBehaviour
{
    public Sprite smallRockSprite, smallerRockSprite, hole;

    public GameObject player, spawnpoint;

    public bool isHole;

    private int hitCount = 0;

    // Reference to the sound clip you want to play
    public AudioClip hitSound; // Sound to play when the rock is hit

    private void Start()
    {
        isHole = false;
    }

    public void TakeHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            GetComponent<SpriteRenderer>().sprite = smallRockSprite;
            PlayHitSound();  // Play sound when rock is hit

        }
        else if (hitCount == 2)
        {
            GetComponent<SpriteRenderer>().sprite = smallerRockSprite;
            PlayHitSound();  // Play sound when rock is hit

        }
        else if (hitCount == 3)
        {
            isHole = true;

            GetComponent<SpriteRenderer>().sprite = hole;
            transform.localScale = Vector3.one;

            // Enable trigger for the hole
            CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
            circleCollider2D.isTrigger = true;
            circleCollider2D.radius = 0.25f;

            PlayHitSound();  // Play sound when rock is hit and becomes a hole
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHole)
        {
            player.transform.position = spawnpoint.transform.position;
        }
    }

    // Method to play the hit sound using the AudioManager
    private void PlayHitSound()
    {
        if (hitSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(hitSound); // Call AudioManager to play the sound
        }
        else
        {
            Debug.LogWarning("Hit sound or AudioManager is missing!");
        }
    }
}
