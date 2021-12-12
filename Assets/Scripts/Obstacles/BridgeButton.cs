using UnityEngine;

public class BridgeButton : MonoBehaviour
{

    [SerializeField] private Bridge bridge;    
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource doorAudio;
    private void Awake() {
        doorAudio.Stop();
    }
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorAudio = GetComponent<AudioSource>();
    } 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(bridge == null){
                Debug.LogError("No bridge Related to this button.");
                return ;
            }
            doorAudio.Play();
            spriteRenderer.sprite = buttonSprites[0];
            bridge.activated = true;   
            bridge.getDown = false;         
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(bridge == null){
                Debug.LogError("No bridge Related to this button.");
                return ;
            }

            spriteRenderer.sprite = buttonSprites[1];
        } 
    }
}
