using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private static Rigidbody2D rb;
    [SerializeField] private Movement movement;
    private float horizontal;
    private Vector3 direction;
    public bool isJumping;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private ParticleSystem particles;

    void Start(){
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        particles = transform.Find("/DeathParticles").GetComponent<ParticleSystem>();
        particles.Stop();
    }
    
    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontal, 0, 0);
        isJumping = Input.GetKey(KeyCode.Space);
    }
    private void FixedUpdate() {
        movement.Move(rb, direction, isJumping);
    }

    public Rigidbody2D GetRigidbody2D(){ return rb; }
    public void Die(){
        Debug.Log("Dead");
        particles.transform.position = transform.position;
        particles.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this);
        
    }

}
