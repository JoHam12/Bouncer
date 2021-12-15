using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private MusicManager musicManager;
    private void Awake() {
        musicManager = GameObject.Find("/MusicManager").GetComponent<MusicManager>();
    }
    private void Update() {
        musicManager.gameMusic.volume = volumeSlider.maxValue - volumeSlider.value;
    }
}
