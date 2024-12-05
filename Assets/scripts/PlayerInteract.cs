using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float raycastDistance = 2f;
    public LayerMask rockLayer;
    public float MiningDistance = 0.5f;

    private Vector2 lastDirection;
    private object currentTargetRock; // Store reference to either NormalRock or RockHole

    public Animator ani; // Animator for mining animations

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        // Bind the Attack action
        playerInput.actions["Attack"].performed += OnAttackPerformed;
    }

    void Update()
    {
        // Update movement direction
        Vector2 currentMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (currentMovement != Vector2.zero)
        {
            lastDirection = currentMovement;
        }
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        // Define the radius of the circle cast
        float circleRadius = MiningDistance; // Adjust as needed

        // Perform a circle cast
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, circleRadius, lastDirection, raycastDistance, rockLayer);

        if (hit.collider != null)
        {
            RockHole rockHole = hit.collider.GetComponent<RockHole>();
            NormalRock normalRock = hit.collider.GetComponent<NormalRock>();
            WormShooting wormShooting = hit.collider.GetComponent<WormShooting>();

            if (rockHole != null)
            {
                currentTargetRock = rockHole;
                ani.SetBool("Mining", true); // Start mining animation
            }
            else if (normalRock != null)
            {
                currentTargetRock = normalRock;
                ani.SetBool("Mining", true); // Start mining animation
            }
            else if (wormShooting != null)
            {
                currentTargetRock = wormShooting;
                ani.SetBool("Mining", true); // Start mining animation
            }
        }
    }


    // Called via Animation Event
    public void MineRock()
    {
        if (currentTargetRock != null)
        {
            if (currentTargetRock is RockHole)
            {
                ((RockHole)currentTargetRock).TakeHit();
            }
            else if (currentTargetRock is NormalRock)
            {
                ((NormalRock)currentTargetRock).TakeHit();
            }
            else if (currentTargetRock is WormShooting)
            {
                ((WormShooting)currentTargetRock).TakeHit();
            }

            ani.SetBool("Mining", false); // Reset animation state
            currentTargetRock = null; // Clear the target
        }
    }

    private void OnDisable()
    {
        if (playerInput != null)
        {
            playerInput.actions["Attack"].performed -= OnAttackPerformed;
        }
    }

    private void OnDrawGizmos()
    {
        // Set the color for the gizmo
        Gizmos.color = Color.red;

        // Define the radius for the circle cast
        float circleRadius = 0.5f; // Adjust this to match the radius in the CircleCast

        // Define the direction of the cast
        Vector3 direction = lastDirection != Vector2.zero ? (Vector3)lastDirection : Vector3.right;

        // Calculate the start and end points of the cast
        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.position + direction * raycastDistance;

        // Draw the starting circle
        Gizmos.DrawWireSphere(startPoint, circleRadius);

        // Draw the ending circle
        Gizmos.DrawWireSphere(endPoint, circleRadius);

        // Draw lines connecting the edges of the start and end circles
        Gizmos.DrawLine(startPoint + (Vector3.up * circleRadius), endPoint + (Vector3.up * circleRadius));
        Gizmos.DrawLine(startPoint - (Vector3.up * circleRadius), endPoint - (Vector3.up * circleRadius));
        Gizmos.DrawLine(startPoint + (Vector3.right * circleRadius), endPoint + (Vector3.right * circleRadius));
        Gizmos.DrawLine(startPoint - (Vector3.right * circleRadius), endPoint - (Vector3.right * circleRadius));
    }


}
