using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour
{
    public GameObject player, spawnpoint;
    public Animator playerAnimator;  // Reference to the player's animator
    public string animationTrigger = "Falling";  // The trigger name for the animation

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Play the animation
        playerAnimator.SetTrigger(animationTrigger);

        // Start the coroutine to wait for the animation to finish
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        // Wait until the animation is finished
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length); // Wait for the animation's length

        // After the animation is done, move the player to the spawnpoint
        player.transform.position = spawnpoint.transform.position;
    }
}
