using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private static Rigidbody2D rb;
    [SerializeField] private Movement movement;
    public float horizontal;
    private Vector3 direction;
    public bool isJumping;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private ParticleSystem particles;
    public bool canMove, isDead;
    [SerializeField] private Button restartButton;
    private int score;
    public bool test;
    [SerializeField] private Vector2 lastGroundPos;
    void Start(){
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        lastGroundPos = transform.position;
        particles = transform.Find("/DeathParticles").GetComponent<ParticleSystem>();
        particles.Stop();
        canMove = true;
        isDead = false;
        score = 0;
        horizontal = 0;
        test = false; // Test with keyboard input
    }
    
    private void Update() {
        if(!canMove){ return ; }
        if(Input.GetKeyDown(KeyCode.N)){
            test = !test;
        }
        if(test){
            horizontal = Input.GetAxisRaw("Horizontal");
            isJumping = Input.GetKey(KeyCode.Space);
        }
        // 
        direction = new Vector3(horizontal, 0, 0);
        Debug.Log(horizontal);
        // 
    }
    private void FixedUpdate() {
        if(!canMove){ return ; }
        
        movement.Move(rb, direction, isJumping);
        if(!groundChecker.GetComponent<CheckGrounded>().isGrounded){
            lastGroundPos = transform.position;
        }
    }

    public Rigidbody2D GetRigidbody2D(){ return rb; }
    public void SetParticleSystem(ParticleSystem particles){ this.particles = particles; }
    public void SetRestartButton(Button button){ restartButton = button; }

    /// <summary>Called after player's death</summary>
    public void Die(){
        Debug.Log("Score : " + score);
        isDead = true;
        particles.transform.position = transform.position;
        particles.Play();
        restartButton.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    /// <summary> Adds 1 to player score </summary>
    public void IncrementScore(){ score += 1; }
    public int GetScore(){ return score; }
    public CheckGrounded GetCheckGrounded(){ return groundChecker.GetComponent<CheckGrounded>(); }
}
