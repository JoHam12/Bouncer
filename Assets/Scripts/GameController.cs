using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject playerInstance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem particles;

    private void Awake() {
        particles.Stop();
    }
    private void Start() {
        SpawnPlayer();
    }
    private void Update() {
        
    }

    public void SpawnPlayer(){
        playerInstance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        cam.SetTarget(playerInstance.transform);
        cam.SetGroundCheck(playerInstance.GetComponentInChildren<CheckGrounded>());
        playerInstance.GetComponent<Player>().SetParticleSystem(particles);
    }
}
