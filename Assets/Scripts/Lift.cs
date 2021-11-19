using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private Rigidbody2D rb;
    private float y;
    private Vector2 initialPosition;
    private bool activated;
    [SerializeField] private float maxDistance, movementTime, minDistance;
    private float mass;
    private void Start(){
        initialPosition = transform.position;
        activated = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        LiftObject();
    }

    public void LiftObject(){

        if(transform.position.y > maxDistance || transform.position.y < minDistance || !activated){ 
            rb.velocity = Vector2.zero;    
            return ;
        }
        
        rb.velocity = (new Vector2(0, (mass * 9.8f) + acceleration));
    }

    public void LiftDown(){
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && transform.position.y <= maxDistance-1 && transform.position.y >= minDistance+1){
            activated = true;
            mass = other.GetComponent<Rigidbody2D>().mass;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            activated = false;
            rb.velocity = Vector2.zero;
        }
    }
}
