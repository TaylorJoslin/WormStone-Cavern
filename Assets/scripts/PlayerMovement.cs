using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movementInput; // Stores the input from the player
    private Vector2 lastDirection = Vector2.down; // Default idle direction (down)

    private static readonly int Direction = Animator.StringToHash("Direction");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
   private static readonly int MiningDirection = Animator.StringToHash("MiningDirection"); // For mining animation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        rb.linearVelocity = movementInput * speed;

        // Update animator parameters for movement
        animator.SetFloat("XInput", movementInput.x);
        animator.SetFloat("YInput", movementInput.y);

        // Determine if the player is moving or idle
        if (movementInput.sqrMagnitude > 0)
        {
            // Update lastDirection to the current movement direction
            lastDirection = movementInput.normalized;

            // Set walking animation parameter
            animator.SetBool(IsWalking, true);

            // Update the direction parameter for the blend tree
            UpdateDirection(movementInput);
        }
        else
        {
            // Player is idle, set walking to false
            animator.SetBool(IsWalking, false);

            // Update idle direction parameters based on lastDirection
            animator.SetFloat("LastX", lastDirection.x);
            animator.SetFloat("LastY", lastDirection.y);
        }
    }

    // Update the direction for mining animation (Blend Tree direction)
    private void UpdateDirection(Vector2 direction)
    {
        // Determine the correct direction based on the movement input (X for horizontal, Y for vertical)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) // More horizontal movement
        {
            if (direction.x > 0) // Right
                animator.SetFloat(MiningDirection, 1f);
            else // Left
                animator.SetFloat(MiningDirection, -1f);
        }
        else // More vertical movement
        {
            if (direction.y > 0) // Up
                animator.SetFloat(MiningDirection, 1f);
            else // Down
                animator.SetFloat(MiningDirection, -1f);
        }
    }

    // Called by the Input System when movement input is detected
    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Call this to start the mining animation
    public void StartMining()
    {
        animator.SetBool("Mining", true);
    }

    // Optionally, stop the mining animation manually if needed
    public void StopMining()
    {
        animator.SetBool("Mining", false);
    }
}
