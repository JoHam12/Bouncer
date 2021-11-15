using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    [SerializeField] private CheckGrounded checkGrounded;
    private void Update() {
        animator.SetBool("isJumping", player.isJumping && checkGrounded.isGrounded);
    }
}
