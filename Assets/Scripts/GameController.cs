using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [Header("Player variables")]
    [SerializeField] private GameObject player;
    private GameObject playerInstance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem deathParticles;
    private bool endLevel;
    private bool start;
    [Header("UI Elements")]
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI timeText, scoreText; 
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI finalTimeText, finalScoreText;
    [SerializeField] private GameObject settingsPanel;
    [Header("Objects To Reposition Restart")]
    [SerializeField] private List<GameObject> coins, platforms, keys;
    [SerializeField] private List<Door> doors;
    [SerializeField] private List<Lift> lifts;
    [SerializeField] private ParticleSystem coinParticles;
    private float timer, timerStart;
    private void Awake() {
        coinParticles.gameObject.SetActive(false);
        coinParticles.Stop();
        start = true;
        deathParticles.Stop();
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

    /// <summary>Spawns player prefab and sets all player variables</summary>
    public void SpawnPlayer(){
        playerInstance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        cam.SetTarget(playerInstance.transform);
        cam.SetGroundCheck(playerInstance.GetComponentInChildren<CheckGrounded>());
        Player playerScript = playerInstance.GetComponent<Player>();
        playerScript.SetParticleSystem(deathParticles);
        playerScript.SetRestartButton(restartButton);
    }
    
    /// <summary>Restarts game </summary>
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

    /// <summary> Loads Main Menu </summary>
    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
    }

    /// <summary> Function to execute when settings button is clicked (player cant move when settingsPanel is on) </summary>
    public void settingsMenuClicked(){
        settingsPanel.SetActive(true);        
        if(playerInstance != null){ playerInstance.GetComponent<Player>().canMove = false; }
    }

    /// <summary> Function to execute when back button is clicked </summary>
    public void BackButtonClicked(){
        settingsPanel.SetActive(false);        
        if(playerInstance != null){ playerInstance.GetComponent<Player>().canMove = true; }
    }
    public bool GetEndLevel(){ return endLevel; }
    public void SetEndLevel(){ endLevel = true; }

    ///<summary> Activates coin particle system at coin position </summary>
    ///<param name="currentCoin"> Coin Transform </param>
    public void ActivateCoinParticle(Transform currentCoin){
        coinParticles.transform.position = currentCoin.position;
        coinParticles.gameObject.SetActive(true);
        coinParticles.Play();
    }

}
