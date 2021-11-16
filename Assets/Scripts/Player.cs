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
    private int score;

    void Start(){
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        
        particles = transform.Find("/DeathParticles").GetComponent<ParticleSystem>();
        particles.Stop();
        canMove = true;
        isDead = false;
        score = 0;

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
        Debug.Log("Score : " + score);
        isDead = true;
        particles.transform.position = transform.position;
        particles.Play();
        restartButton.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    public void IncrementScore(){ score += 1; }
    public int GetScore(){ return score; }
}
