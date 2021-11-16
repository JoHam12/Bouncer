using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject playerInstance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem particles;
    public bool endLevel;
    [SerializeField] private Button restartButton;

    private void Awake() {
        particles.Stop();
    }
    private void Start() {
        Restart();
    }
    private void Update() {
        if(!playerInstance){ return ; }
        Player playerInst = playerInstance.GetComponent<Player>();
        if(endLevel){
            Debug.Log("EndLevel");
            playerInst.canMove = false;
            playerInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if(!restartButton.gameObject.activeInHierarchy){ restartButton.gameObject.SetActive(true); }
        }
    }

    public void SpawnPlayer(){
        playerInstance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        cam.SetTarget(playerInstance.transform);
        cam.SetGroundCheck(playerInstance.GetComponentInChildren<CheckGrounded>());
        playerInstance.GetComponent<Player>().SetParticleSystem(particles);
        playerInstance.GetComponent<Player>().SetRestartButton(restartButton);
    }

    public void Restart(){
        restartButton.gameObject.SetActive(false);
        SpawnPlayer();
        endLevel = false;
    }
}
