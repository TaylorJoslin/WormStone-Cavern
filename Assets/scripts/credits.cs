using UnityEngine;

public class credits : MonoBehaviour
{
    [Header("UI Panel Settings")]
    public GameObject panel; // The UI panel to toggle

    // This method is called when the button is clicked
    public void TogglePanel()
    {
        // Check if the panel exists, then toggle its active state
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
}
