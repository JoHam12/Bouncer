using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded, boostJump;
    public float boostValue;
    [SerializeField] private GameObject trailTransform;
    void Start(){
        isGrounded = true;
        boostJump = false;
        boostValue = 0;
    }
    private void FixedUpdate() {
        trailTransform.SetActive(!isGrounded);
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
