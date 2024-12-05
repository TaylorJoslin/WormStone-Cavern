using UnityEngine;
using System.Collections;

public class WormShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint;         // The position from where the projectile will be fired
    public float projectileSpeed = 5f;  // Speed of the projectile
    public float fireRate = 1f;         // Time interval between shots
    public float attackRange = 5f;      // Attack range of the worm

    private float nextFireTime = 0f;

    private int hitCount = 0;
    private bool canTakeHit = true; // Cooldown flag
    public float hitCooldown = 1f; // Cooldown duration in seconds

    void Update()
    {
        // Find the player by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Check if the player is within range
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= attackRange && Time.time >= nextFireTime)
            {
                ShootAtPlayer(player.transform.position);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public void TakeHit()
    {
        if (!canTakeHit) return; // Ignore hits during cooldown

        hitCount++;

        if (hitCount == 1)
        {
            Destroy(gameObject); // Destroy 
        }


        StartCoroutine(HitCooldown());
    }

    private IEnumerator HitCooldown()
    {
        canTakeHit = false; // Disable further hits
        yield return new WaitForSeconds(hitCooldown); // Wait for cooldown duration
        canTakeHit = true; // Enable hits again
    }

    void ShootAtPlayer(Vector2 targetPosition)
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Calculate direction to the player
        Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;

        // Apply velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

    // Draw the attack range in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
