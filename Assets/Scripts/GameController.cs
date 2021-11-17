using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;


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
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI finalTimeText, finalScoreText;
    private void Awake() {
        particles.Stop();
    }
    private void Start() {
        Restart();
    }
    private void Update() {

        if(playerInstance == null){ return ; }
        Player playerInst = playerInstance.GetComponent<Player>();
        if(endLevel){
            Debug.Log("EndLevel");
            playerInst.canMove = false;
            playerInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "Score : " + playerInst.GetScore();
            finalTimeText.gameObject.SetActive(true);
            finalTimeText.text = "Time : " + timer;
            menuButton.gameObject.SetActive(true);
            return ;
        }
        timer = Time.time - timerStart;
        timeText.text = "Time : " + (int) timer;

        if(!playerInstance){ return ; }
        
        scoreText.text = "Score : " + playerInst.GetScore();
        
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

    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
    }


}
