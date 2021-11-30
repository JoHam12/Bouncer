using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private Door doorTarget;
    [SerializeField] private string color;
    [Header("UI Elements")]
    [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keyImageAfter;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            keyImage.sprite = keyImageAfter;
            doorTarget.SetHasKey();
            gameObject.SetActive(false);
        }
    }
}
