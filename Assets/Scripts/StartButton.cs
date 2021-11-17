using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class StartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Color initialColor, onHighlitedColor;
    
    private void Start() {
        startButton = GetComponent<Button>();
    }
    public void StartButtonClicked(){

    }
    
}
