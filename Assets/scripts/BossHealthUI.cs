using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    [Header("References")]
    public BossWormSpawn bossSpawner; // Reference to the spawner script
    public RectTransform hpPanel; // Reference to the RectTransform of the Panel

    private float originalWidth;

    void Start()
    {
        if (hpPanel != null)
        {
            // Store the original width of the Panel for scaling
            originalWidth = hpPanel.sizeDelta.x;
        }
    }

    void Update()
    {
        if (bossSpawner != null && hpPanel != null)
        {
            // Calculate the new width based on the boss's HP
            float healthRatio = Mathf.Clamp01((float)bossSpawner.bossHP / bossSpawner.maxWorms);
            Vector2 newSize = new Vector2(originalWidth * healthRatio, hpPanel.sizeDelta.y);
            hpPanel.sizeDelta = newSize;
        }
    }
}
