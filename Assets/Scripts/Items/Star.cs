using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            gameController.SetHasStar();
            audioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
