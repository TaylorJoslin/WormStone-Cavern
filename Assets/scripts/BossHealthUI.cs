using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [Header("References")]
    public BossWormSpawn bossSpawner; // Reference to the spawner script
    public Image hpPanel;             // Reference to the Image component with fill amount

    void Update()
    {
        if (bossSpawner != null && hpPanel != null)
        {
            // Calculate the fill amount based on the boss's HP
            float healthRatio = Mathf.Clamp01((float)bossSpawner.bossHP / 100f); // Assuming max HP is 100
            hpPanel.fillAmount = healthRatio;
        }
    }
}
