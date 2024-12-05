using UnityEngine;
using System.Collections;

public class NormalRock : MonoBehaviour
{
    

    private int hitCount = 0;
    private bool canTakeHit = true; // Cooldown flag
    public float hitCooldown = 1f; // Cooldown duration in seconds

    public void TakeHit()
    {
        if (!canTakeHit) return; // Ignore hits during cooldown

        hitCount++;

        if (hitCount == 1)
        {
            Destroy(gameObject); // Destroy the rock
        }
      

        StartCoroutine(HitCooldown());
    }

    private IEnumerator HitCooldown()
    {
        canTakeHit = false; // Disable further hits
        yield return new WaitForSeconds(hitCooldown); // Wait for cooldown duration
        canTakeHit = true; // Enable hits again
    }
}
