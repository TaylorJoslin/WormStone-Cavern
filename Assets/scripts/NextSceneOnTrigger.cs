using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnTrigger : MonoBehaviour
{
    // Reference to the sound effect to play when the level changes
    public AudioClip levelChangeSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the sound effect
            PlayLevelChangeSound();

            // Load the next scene
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("No more scenes in the build order!");
            }
        }
    }

    public void NextScene()
    {
        // Play the sound effect
        PlayLevelChangeSound();

        // Load the next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes in the build order!");
        }
    }

    // Play the level change sound
    private void PlayLevelChangeSound()
    {
        if (levelChangeSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShotAudio(levelChangeSound);
        }
        else
        {
            Debug.LogWarning("Level change sound or AudioManager is missing!");
        }
    }
}
