using UnityEngine;

public class IntroSignScript : MonoBehaviour
{
    public GameObject IntroSignPanel; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (IntroSignPanel != null)
        {
            IntroSignPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IntroSignPanel != null)
        {
            IntroSignPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IntroSignPanel != null)
        {
            IntroSignPanel.SetActive(false);
        }
    }
}
