using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private void Awake() {
        audioSource.Stop();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other !=null && other.CompareTag("Player")){
            other.GetComponent<Player>().Die();
            audioSource.Play();
        }
    }
}
