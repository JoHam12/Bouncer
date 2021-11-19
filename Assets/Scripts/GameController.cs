using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool start;
    private GameObject playerInstance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem particles;
    public bool endLevel;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> coins, platforms, keys;
    [SerializeField] private List<Door> doors;
    [SerializeField] private List<Lift> lifts;
    private float timer, timerStart;
    [SerializeField] private TextMeshProUGUI timeText, scoreText; 
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI finalTimeText, finalScoreText;
    [SerializeField] private GameObject settingsPanel;
    private void Awake() {
        start = true;
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
            restartButton.gameObject.SetActive(true);
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
        finalScoreText.gameObject.SetActive(false);
        finalTimeText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        timerStart = Time.time;
        foreach (GameObject coin in coins){
            coin.SetActive(true);
            coin.GetComponent<Collider2D>().enabled = true;
        }
        foreach (GameObject key in keys){ key.SetActive(true); }
        foreach (GameObject platform in platforms){ 
            platform.GetComponent<DestroyablePlatform>().Reactivate();
            platform.SetActive(true);
        }
        foreach(Door door in doors){ door.CloseDoor(); }
        foreach(Lift lift in lifts){ lift.LiftDown(); }
        restartButton.gameObject.SetActive(false);
        if(start){ 
            SpawnPlayer();
            endLevel = false;
            start = false;
            return ;
            
        }
        Destroy(playerInstance);
        SpawnPlayer();
        endLevel = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
    }
    public void settingsMenuClicked(){
        settingsPanel.SetActive(true);        
        if(playerInstance != null){ playerInstance.GetComponent<Player>().canMove = false; }
    }
    public void BackButtonClicked(){
        settingsPanel.SetActive(false);        
        if(playerInstance != null){ playerInstance.GetComponent<Player>().canMove = true; }
    }
    

}
