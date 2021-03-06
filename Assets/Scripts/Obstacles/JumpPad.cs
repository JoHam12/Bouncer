using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForceValue;
    private Player player;
    [SerializeField] private AudioSource jumpEffect;
    private void Awake() {
        jumpEffect = GetComponent<AudioSource>();
        jumpEffect.Stop();
    } 
    public float GetJumpForceValue(){ return jumpForceValue; }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = other.gameObject.GetComponent<Player>();
            player.GetRigidbody2D().AddForce(Vector2.up * jumpForceValue, ForceMode2D.Force);
            jumpEffect.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = null;
        }
    }
}
