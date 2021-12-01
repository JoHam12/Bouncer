using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level : MonoBehaviour
{
    [SerializeField] private bool isUnLocked;
    [SerializeField] private int levelId;
    [SerializeField] private Color unlockedColor;
    [SerializeField] private Image buttonImage;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private TextMeshProUGUI highScoreText, bestTimeText;
    [SerializeField] private Button button;
    private void Start() {
        if(levelId == 0){ 
            isUnLocked = true; 
            highScoreText.gameObject.SetActive(true);
            bestTimeText.gameObject.SetActive(true);
            button.enabled = true;
            if(SaveSystem.LoadData(levelId) == null){
                highScoreText.text = "High Score : 0";
                bestTimeText.text = "Best Time : 0";
                return ;
            }
            Data data = SaveSystem.LoadData(levelId);

            highScoreText.text = "High Score : " + data.score.ToString();
            bestTimeText.text = "Best Time : " + data.time.ToString();

            return ; 
        }
        button.interactable = false;
        if(SaveSystem.LoadData(levelId - 1) == null){ 
            return ; 
        }
        isUnLocked = SaveSystem.LoadData(levelId - 1).starTaken;
        button.interactable = isUnLocked;
        if(isUnLocked){
            buttonImage.color = unlockedColor;
            lockObj.SetActive(false);
            highScoreText.gameObject.SetActive(true);
            bestTimeText.gameObject.SetActive(true);
            if(SaveSystem.LoadData(levelId) == null){
                highScoreText.text = "High Score : 0";
                bestTimeText.text = "Best Time : 0";
                return ;
            }
            Data data = SaveSystem.LoadData(levelId);

            highScoreText.text = "High Score : " + data.score.ToString();
            bestTimeText.text = "Best Time : " + data.time.ToString();
            return ;
        }
        highScoreText.gameObject.SetActive(false);
        bestTimeText.gameObject.SetActive(false);
    }
}
