using UnityEngine;

public class Spike : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other !=null && other.CompareTag("Player")){
            other.GetComponent<Player>().Die();
        }
    }
}
