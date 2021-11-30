using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private ParticleSystem coinParticles;
    [SerializeField] private AudioSource audioSource;
    private void Awake() {
        audioSource.Stop();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            coinParticles.Play();
            audioSource.Play();
            other.GetComponent<Player>().IncrementScore();
            circleCollider2D.enabled = false;
            gameObject.SetActive(false);
            Debug.Log("Got one : " + gameObject);
        }
    }
}
