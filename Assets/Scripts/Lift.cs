using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private Rigidbody2D rb;
    private float y;
    private Vector2 initialPosition;
    [Header("Positional Variables")]
    [SerializeField] private float maxPosition, movementTime, minPosition;
    private float mass;
    private bool activated;
    private void Start(){
        initialPosition = transform.position;
        activated = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        LiftObject();
        LiftDownSlower();
    }

    /// <summary>Moves player upwards </summary>
    public void LiftObject(){
        if(transform.position.y > maxPosition || transform.position.y < minPosition || !activated){ 
            rb.velocity = Vector2.zero;    
            return ;
        }
        
        rb.velocity = (new Vector2(0, (mass * 9.8f) + acceleration));
    }

    ///<summary>Reposition lift</summary>
    public void LiftDown(){
        transform.position = initialPosition;
    }

    /// <summary> Move lift downwards slowly </summary>
    public void LiftDownSlower(){
        if(activated){ return ; }
        if(transform.position.y <= initialPosition.y + .1f){ 
            rb.velocity = Vector2.zero; 
            return ; 
        }
        rb.velocity = new Vector2(0, -acceleration);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && transform.position.y <= maxPosition-1 && transform.position.y >= minPosition+1){
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
