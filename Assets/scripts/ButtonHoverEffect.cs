using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1);
    public Vector3 normalScale = new Vector3(1f, 1f, 1);

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.localScale = hoverScale;  // Scale up on hover
        // Optionally, add a sound or additional effects here
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.localScale = normalScale;  // Scale back to normal
    }
}
