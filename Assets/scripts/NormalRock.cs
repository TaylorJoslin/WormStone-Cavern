using UnityEngine;

public class NormalRock : MonoBehaviour
{
    public Sprite smallRockSprite, smallerRockSprite;

    private int hitCount = 0;

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
        else if (hitCount == 3)
        {
            Destroy(gameObject);
        }
    }
}
