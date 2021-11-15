using UnityEngine;

public class Spike : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player")){
            other.collider.GetComponent<Player>().Die();
        }
    }
}
