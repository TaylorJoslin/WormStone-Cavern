using UnityEngine;
using UnityEngine.UIElements;

public class Rock : MonoBehaviour
{
    public Sprite smallRockSprite; // Assign in the Inspector
    public Sprite smallerRockSprite; // Assign in the Inspector
    public Sprite hole;
    private int hitCount = 0;

    public void TakeHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            // Change to smaller sprite
            GetComponent<SpriteRenderer>().sprite = smallRockSprite;
        }
        else if (hitCount == 2)
        {
            // Change to smaller sprite
            GetComponent<SpriteRenderer>().sprite = smallerRockSprite;
        }
        else if(hitCount == 3)
        {
            // Destroy the rock
            GetComponent<SpriteRenderer>().sprite = hole;
            transform.localScale = Vector3.one;
            
            CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
            circleCollider2D.isTrigger = true;
            circleCollider2D.radius = 0.4523363f;
        }
    }
}
