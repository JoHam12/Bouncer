using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded;
    public bool boostJump;
    public float boostValue;
    void Start(){
        isGrounded = true;
        boostJump = false;
        boostValue = 0;
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
