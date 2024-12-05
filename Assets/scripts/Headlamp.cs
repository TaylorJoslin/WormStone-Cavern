using UnityEngine;

public class Headlamp : MonoBehaviour
{
    public GameObject HeadlampPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadLamp"))
        {
            HeadlampPrefab.SetActive(true);
        }
        
    }
}
