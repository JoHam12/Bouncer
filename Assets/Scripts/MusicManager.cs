using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource gameMusic { get ; private set ; }
    private static MusicManager instance;
    private void Start() {
        gameMusic = GetComponent<AudioSource>();
        if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
