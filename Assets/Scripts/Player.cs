using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private static Rigidbody2D rb;
    [SerializeField] private Movement movement;
    private float horizontal;
    private Vector3 direction;
    public bool isJumping;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private ParticleSystem particles;
    public bool canMove, isDead;
    [SerializeField] private Button restartButton;

    void Start(){
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        
        particles = transform.Find("/DeathParticles").GetComponent<ParticleSystem>();
        particles.Stop();
        canMove = true;
        isDead = false;
        
    }
    
    private void Update() {
        if(!canMove){ return ; }
        horizontal = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontal, 0, 0);
        isJumping = Input.GetKey(KeyCode.Space);
    }
    private void FixedUpdate() {
        if(!canMove){ return ; }
        movement.Move(rb, direction, isJumping);
    }

    public Rigidbody2D GetRigidbody2D(){ return rb; }
    public void SetParticleSystem(ParticleSystem particles){ this.particles = particles; }
    public void SetRestartButton(Button button){ restartButton = button; }
    public void Die(){
        isDead = true;
        particles.transform.position = transform.position;
        particles.Play();
        restartButton.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

}
