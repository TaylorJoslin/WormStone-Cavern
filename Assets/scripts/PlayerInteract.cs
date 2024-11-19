using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float raycastDistance = 1f;
    public LayerMask rockLayer;
    private Vector2 lastDirection; // Stores the direction for the raycast
    private bool isRaycastActive = false;

    void Update()
    {
        Vector2 currentMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (currentMovement != Vector2.zero)
        {
            lastDirection = currentMovement; // Update direction while the player is moving
        }

        if (IsInteractPressed())
        {
            isRaycastActive = !isRaycastActive; // Toggle raycast on/off
        }

        if (isRaycastActive)
        {
            MaintainRaycast();
        }
    }

    private bool IsInteractPressed()
    {
        // Replace with your Input System logic
        return Input.GetKeyDown(KeyCode.E); // Placeholder for testing
    }

    private void MaintainRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, raycastDistance, rockLayer);

        if (hit.collider != null)
        {
            Rock rock = hit.collider.GetComponent<Rock>();
            if (rock != null)
            {
                rock.TakeHit();
                isRaycastActive = false; // Turn off raycast after a successful interaction
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (isRaycastActive)
        {
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)(lastDirection * raycastDistance));
        }
    }
}
