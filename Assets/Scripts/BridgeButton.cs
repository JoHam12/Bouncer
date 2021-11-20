using UnityEngine;

public class BridgeButton : MonoBehaviour
{

    [SerializeField] private Bridge bridge;    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(bridge == null){
                Debug.LogError("No bridge Related to this button.");
                return ;
            }
            bridge.activated = true;   
            bridge.getDown = false;         
        }
    }
}
