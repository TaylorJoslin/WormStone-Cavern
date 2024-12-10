using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image heartImage; // UI Image to represent the health
    public Sprite[] heartSprites; // Array of heart sprites (full, 3/4, 1/2, 1/4, empty)
    public GameObject gameOverPanel; // The panel containing Game Over UI elements
    public AudioClip damageSound; // Audio clip to play when the player takes damage

    private int currentHealth = 9; // Total of 4 quarters of a heart
    private int maxHealth = 9;     // Max health of the player

    void Start()
    {
        // Ensure the Game Over panel is initially hidden
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        // Set the initial health image to the correct sprite
        UpdateHeartDisplay();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHeartDisplay();

            // Play damage sound
            PlayDamageSound();

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    public void HealHP()
    {
        if (currentHealth < maxHealth) // Check if health is less than the max
        {
            currentHealth++;
            UpdateHeartDisplay();
        }
    }

    void UpdateHeartDisplay()
    {
        // Check if heartSprites has enough elements, then update the heart image
        if (heartSprites.Length >= currentHealth)
        {
            heartImage.sprite = heartSprites[currentHealth];
        }
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

    // Play the damage sound when the player takes damage
    private void PlayDamageSound()
    {
        if (damageSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(damageSound);
        }
        else
        {
            Debug.LogWarning("Damage sound or AudioManager is missing!");
        }
    }
}
