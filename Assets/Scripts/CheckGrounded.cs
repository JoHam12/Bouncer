using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded, boostJump;
    [SerializeField] private ParticleSystem trailParticle;
    void Start(){
        isGrounded = true;
        boostJump = false;
    
    }
    private void FixedUpdate() {
        if(!isGrounded){ trailParticle.Play(); }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Floor")){
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Floor")){
            isGrounded = false;
        }
    }
}
