using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float raycastDistance = 2f;
    public LayerMask rockLayer;

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
        // Perform raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, raycastDistance, rockLayer);

        if (hit.collider != null)
        {
            RockHole rockHole = hit.collider.GetComponent<RockHole>();
            NormalRock normalRock = hit.collider.GetComponent<NormalRock>();

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
}
