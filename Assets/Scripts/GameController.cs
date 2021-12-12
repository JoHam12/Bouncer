using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameController : MonoBehaviour
{
    [Header("Player variables")]
    [SerializeField] private GameObject player;
    private GameObject playerInstance;
    private Player playerScript;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private ParticleSystem deathParticles;
    private bool endLevel;
    private bool start;
    [Header("UI Elements")]
    [SerializeField] private Button restartButton, doubleScoreButton;
    [SerializeField] private TextMeshProUGUI timeText, scoreText; 
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI finalTimeText, finalScoreText;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private MovementButton leftButton, rightButton, jumpButton;
    [Header("Objects To Reposition Restart")]
    [SerializeField] private List<GameObject> keys;
    [SerializeField] private List<DestroyablePlatform> platforms;
    [SerializeField] private List<Coin> coins;
    [SerializeField] private List<Door> doors;
    [SerializeField] private List<Lift> lifts;
    [Header("Score")]
    [SerializeField] private int highScore;
    [SerializeField] private float bestTime;
    [SerializeField] private int levelId;
    [SerializeField] private bool hasStar;
    [SerializeField] private AdsManager ads;
    private float timer, timerStart;
    public bool canSpawn;
    public bool getReward;
    private void Awake() {
        start = true;
        deathParticles.Stop();
        Data data = SaveSystem.LoadData(levelId);
        hasStar = false;
        if(data == null){ return ; }
        SetBestTime(data);
        SetHighScore(data);
        hasStar = data.starTaken;
        canSpawn = false;
        getReward = false;
    }
    private void Start() {
        Restart();
    }
    private void Update() {
        if(canSpawn){
            timerStart = Time.time;
            SpawnPlayer();
            endLevel = false;
            canSpawn = false;
        }
        if(getReward){
            
        }

        if(playerInstance == null){ return ; }
        
        
        if(endLevel){
            Debug.Log("EndLevel");
            playerScript.canMove = false;
            playerInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "Score : " + playerScript.GetScore();
            finalTimeText.gameObject.SetActive(true);
            finalTimeText.text = "Time : " + timer;
            if(playerScript.GetScore() >= highScore){
                if(playerScript.GetScore() > highScore){
                    Debug.Log("New HighScore");
                    highScore = playerScript.GetScore();
                }
                if(timer <= bestTime || bestTime == 0){
                    bestTime = timer;
                }

                SaveSystem.SavePlayer(playerScript, this);
            }
            menuButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            doubleScoreButton.gameObject.SetActive(true);
            return ;
        }
        timer = Time.time - timerStart;
        timeText.text = "Time : " + (int) timer;
        
        if(!playerInstance){ return ; }
        
        scoreText.text = "Score : " + playerScript.GetScore();
        
    }

    /// <summary>Spawns player prefab and sets all player variables</summary>
    private void SpawnPlayer(){
        playerInstance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        cam.SetTarget(playerInstance.transform);
        cam.SetGroundCheck(playerInstance.GetComponentInChildren<CheckGrounded>());
        playerScript = playerInstance.GetComponent<Player>();
        playerScript.SetParticleSystem(deathParticles);
        playerScript.SetRestartButton(restartButton);

        rightButton.SetPlayer(playerScript);
        leftButton.SetPlayer(playerScript);
        jumpButton.SetPlayer(playerScript);

    }
    
    /// <summary>Restarts game </summary>
    public void Restart(){
        finalScoreText.gameObject.SetActive(false);
        finalTimeText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        
        foreach (Coin coin in coins){
            coin.gameObject.SetActive(true);
            coin.GetComponentInChildren<Collider2D>().enabled = true;
        }
        foreach (GameObject key in keys){ key.SetActive(true); }
        foreach (DestroyablePlatform platform in platforms){ 
            platform.Reactivate();
            platform.gameObject.SetActive(true);
        }
        foreach(Door door in doors){ 
            door.CloseDoor();
            door.SetKeyImageUI();
        }
        foreach(Lift lift in lifts){ lift.LiftDown(); }
        restartButton.gameObject.SetActive(false);
        doubleScoreButton.gameObject.SetActive(false);
        
        timerStart = Time.time;
        if(start){ 
            SpawnPlayer();
            endLevel = false;
            start = false;
            return ;
            
        }
        Destroy(playerInstance);
        ads.PlayAd();

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

    public void DoubleScore(){
        ads.PlayRewardedAd();
    }
    public bool GetEndLevel(){ return endLevel; }
    public void SetEndLevel(){ endLevel = true; }

    ///<summary> Moves Player Left (used for buttons) </summary>
    public void MovePlayerLeft(){
        if(playerScript == null){ return ; }
        playerScript.horizontal = -1;
    }
    ///<summary> Moves Player Right (used for buttons) </summary>
    public void MovePlayerRight(){
        
        if(playerScript == null){ return ; }
        Debug.Log("Clicked");
        playerScript.horizontal = 1;
    }



    public float GetTime(){ return timer; }
    public int GetLevel(){ return levelId; }
    public void SetLevelId(int id){ levelId = id; }
    /// <summary> Sets highScore from saved data </summary>
    /// <param name="data"> saved data </param>
    public void SetHighScore(Data data){ highScore = data.score; }
    /// <summary> Sets bestTime from saved data </summary>
    /// <param name="data"> saved data </param>
    public void SetBestTime(Data data){ bestTime = data.time; }
    public bool GetHasStar(){ return hasStar; }
    public void SetHasStar(){ hasStar = true; }

    // IEnumerator PlayAdTillCompletion(){
    //     if(ads.)

    //     yield return null;
    // }
}
