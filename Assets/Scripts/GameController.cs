using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject playerInstance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem particles;
    public bool endLevel;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> coins;
    private float timer, timerStart;
    [SerializeField] private TextMeshProUGUI timeText, scoreText; 
    private void Awake() {
        particles.Stop();
    }
    private void Start() {
        Restart();
    }
    private void Update() {
        timer = Time.time - timerStart;
        timeText.text = "Time : " + (int) timer;

        if(!playerInstance){ return ; }
        Player playerInst = playerInstance.GetComponent<Player>();
        scoreText.text = "Score : " + playerInst.GetScore();
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
        Player playerScript = playerInstance.GetComponent<Player>();
        playerScript.SetParticleSystem(particles);
        playerScript.SetRestartButton(restartButton);
    }

    public void Restart(){
        timerStart = Time.time;
        foreach (GameObject coin in coins){
            coin.SetActive(true);
            coin.GetComponent<Collider2D>().enabled = true;
        }
        restartButton.gameObject.SetActive(false);
        SpawnPlayer();
        endLevel = false;
    }
}
