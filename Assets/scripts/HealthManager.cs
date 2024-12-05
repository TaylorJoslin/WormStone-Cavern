using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image heartImage; // UI Image to represent the health
    public Sprite[] heartSprites; // Array of heart sprites (full, 3/4, 1/2, 1/4, empty)
    public GameObject gameOverPanel; // The panel containing Game Over UI elements

    private int currentHealth = 8; // Total of 4 quarters of a heart

    void Start()
    {
        // Ensure the Game Over panel is initially hidden
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHeartDisplay();

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateHeartDisplay()
    {
        // Update the heart image based on the remaining health
        heartImage.sprite = heartSprites[currentHealth];
    }

    void GameOver()
    {
        // Pause the game
        Time.timeScale = 0;

        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RetryGame()
    {
        // Unpause the game
        Time.timeScale = 1;

        // Destroy persistent objects
        DestroyPersistentObjects();

        // Load the first scene
        SceneManager.LoadScene(0);
    }

    void DestroyPersistentObjects()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }

        var canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            Destroy(canvas.gameObject);
        }
    }
}
