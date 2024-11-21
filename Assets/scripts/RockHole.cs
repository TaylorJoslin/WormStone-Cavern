using UnityEngine;
using System.Collections;
public class RockHole : MonoBehaviour
{
    public Sprite smallRockSprite, smallerRockSprite, hole;

    public GameObject player, spawnpoint;

    public Animator animator;

    public bool isHole;

    private int hitCount = 0;
    private bool canTakeHit = true; // Cooldown flag
    public float hitCooldown = 1f; // Cooldown duration in seconds

    private void Start()
    {
        isHole = false;
    }

    public void TakeHit()
    {
        if (!canTakeHit) return; // Ignore hits during cooldown

        hitCount++;

        if (hitCount == 1)
        {
            GetComponent<SpriteRenderer>().sprite = smallRockSprite;
        }
        else if (hitCount == 2)
        {
            GetComponent<SpriteRenderer>().sprite = smallerRockSprite;
        }
        else if (hitCount == 3)
        {
            isHole = true;
            GetComponent<SpriteRenderer>().sprite = hole;
            transform.localScale = Vector3.one;

            CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
            circleCollider2D.isTrigger = true;
            circleCollider2D.radius = 0.3f;
        }

        StartCoroutine(HitCooldown()); // Start cooldown
    }

    private IEnumerator HitCooldown()
    {
        canTakeHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canTakeHit = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHole)
        {
            player.transform.position = spawnpoint.transform.position;
        }
    }


}
