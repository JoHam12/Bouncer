using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    [SerializeField] private CheckGrounded checkGrounded;
    private void Update() {

        // Play animation if player is not on the ground
        animator.SetBool("isJumping", !checkGrounded.isGrounded);
    }
    /// <summary>
    /// Sets player attribute.
    /// </summary>
    ///<param name = "player"> value to set player to </param>
    public void SetPlayer(Player player){ this.player = player; }

    /// <summary>
    /// Sets checkGrounded attribute.
    /// </summary>
    public void SetCheckGrounded(){
        if(this.player==null){  Debug.LogError("Can't find Player"); }
        this.checkGrounded = player.GetCheckGrounded();
    }

    /// <summary>
    /// Sets animator attribute.
    /// </summary>
    public void SetAnimator(){
        if(this.player==null){  Debug.LogError("Can't find Player"); }
        this.animator = player.GetComponent<Animator>();
    }
}
