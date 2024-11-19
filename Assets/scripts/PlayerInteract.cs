using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 2f;
    [SerializeField] private LayerMask rockLayer;
    private Vector2 lastDirection; // Stores the direction for the raycast
    private bool isRaycastActive = false;

    void Update()
    {
        // Update movement direction
        Vector2 currentMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (currentMovement != Vector2.zero)
        {
            lastDirection = currentMovement; // Update direction while the player is moving
        }

        if (isRaycastActive)
        {
            MaintainRaycast();
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed) // Ensure the action triggers only on press
        {
            isRaycastActive = !isRaycastActive; // Toggle the raycast
        }
    }

    private void MaintainRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, raycastDistance, rockLayer);

        if (hit.collider != null)
        {
            RockWithHole rock = hit.collider.GetComponent<RockWithHole>();
            if (rock != null)
            {
                rock.TakeHit();
                isRaycastActive = false; // Turn off raycast after a successful interaction
            }
        }

        //dectects if a rock is infront of the player and hits it if it is a normal rock
        if (hit.collider != null)
        {
            NormalRock rock = hit.collider.GetComponent<NormalRock>();
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