using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider2D;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Player>().IncrementScore();
            circleCollider2D.enabled = false;
            gameObject.SetActive(false);
            Debug.Log("Got one : " + gameObject);
        }
    }
}
