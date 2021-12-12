using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded, boostJump;
    void Start(){
        isGrounded = true;
        boostJump = false;
    
    }
    private void FixedUpdate() {
        
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
