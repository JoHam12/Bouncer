using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource gameMusic;
    private void Start() {
        gameMusic = GetComponent<AudioSource>();
    }
    private void Update() {
        DontDestroyOnLoad(this.gameObject);
    }

}
