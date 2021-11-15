using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpingForce;
    [SerializeField] private CheckGrounded checkGrounded;
    [SerializeField] private float maxSpeed;
    
    public void Move(Rigidbody2D rb, Vector3 direction, bool isJumping){
        if(isJumping && checkGrounded.isGrounded){
            rb.AddForce(Vector2.up * jumpingForce);
        }
        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        rb.AddForce(direction.normalized * acceleration);
              

    }
}
