using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private static Rigidbody2D rb;
    [SerializeField] private Movement movement;
    private float horizontal;
    private Vector3 direction;
    public bool isJumping;
    [SerializeField] private Transform groundChecker;

    void Start(){
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }
    
    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontal, 0, 0);
        isJumping = Input.GetKey(KeyCode.Space);
    }
    private void FixedUpdate() {
        movement.Move(rb, direction, isJumping);
    }
}
