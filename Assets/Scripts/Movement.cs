using UnityEngine;

[System.Serializable]
public class Movement : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpingForce;
    [SerializeField] private CheckGrounded checkGrounded;
    [SerializeField] private float maxSpeed;
    
    /// <summary>Accelerates object in given direction at acceleration attribute
    /// until it reaches maxSpeed and if jumping and grounded applies force in dir vect(0, 1) 
    /// </summary>

    /// <param name="rb"> Player's RigidBody</param>
    /// <param name="direction"> Movement direction</param>
    /// <param name="isJumping"> Checks if player is jumping </param>
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
