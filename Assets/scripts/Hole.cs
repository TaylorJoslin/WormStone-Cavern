using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player,spawnpoint;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = spawnpoint.transform.position;
    }
}
