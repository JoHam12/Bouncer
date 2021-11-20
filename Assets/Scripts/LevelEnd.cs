using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    [SerializeField] private GameController gameController;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            gameController.SetEndLevel();
        }
    }
}
