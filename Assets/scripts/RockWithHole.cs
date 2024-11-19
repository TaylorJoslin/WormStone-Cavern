using UnityEngine;
using UnityEngine.UIElements;

public class RockWithHole : MonoBehaviour
{
    public Sprite smallRockSprite, smallerRockSprite,hole;

    public GameObject player, spawnpoint;

    public bool isHole;

    private int hitCount = 0;

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
        }
        else if (hitCount == 2)
        {
            
            GetComponent<SpriteRenderer>().sprite = smallerRockSprite;
        }
        else if(hitCount == 3)
        {
            isHole = true;

            
            GetComponent<SpriteRenderer>().sprite = hole;
            transform.localScale = Vector3.one;
            
            CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
            circleCollider2D.isTrigger = true;
            circleCollider2D.radius = 0.25f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHole)
        {
            player.transform.position = spawnpoint.transform.position;
        }
        
        
    }
}
