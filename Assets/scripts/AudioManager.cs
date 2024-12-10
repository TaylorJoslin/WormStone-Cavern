using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton reference
    public AudioSource audioSource; // The AudioSource to play sounds

    private void Awake()
    {
        // Singleton pattern to make sure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the AudioManager between scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void PlayOneShotAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Play the sound
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip missing!");
        }
    }
}
