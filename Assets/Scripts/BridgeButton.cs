using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    [SerializeField] private Bridge bridge;
    [SerializeField] private float forceValue;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            bridge.activated = true;   
            bridge.getDown = false;         
        }
    }
}
