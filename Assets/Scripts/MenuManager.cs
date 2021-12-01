using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, settingsMenu, selectionMenu;
    [SerializeField] private List<string> scenes;
    [SerializeField] private TextMeshProUGUI moneyText;
    private int moneyValue;
    private void Update() {
        moneyValue = 0;
        for(int i = 0; i < scenes.Count; i++){
            Data data = SaveSystem.LoadData(i);
            if(data != null){ moneyValue += data.score; }
        }
        moneyText.text = moneyValue.ToString();
    }
    /// <summary> Show Settings Panel </summary>
    public void SettingsButtonClicked(){
        mainMenu.SetActive(false);
        selectionMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    /// <summary> Back to main menu </summary>
    public void BackButtonClicked(){
        settingsMenu.SetActive(false);
        selectionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    /// <summary> Show selection panel </summary>
    public void StartButtonClicked(){
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        selectionMenu.SetActive(true);

    }

    /// <summary> Load level </summary>
    /// <param name="levelId"> Level id to load </param>
    public void LoadLevel(int levelId){
        SceneManager.LoadScene(scenes[levelId]);
    }

    /// <summary> Delete player overall progress </summary>
    /// <param name="numberOfLevels"> Number of active levels </param>
    public void DeletePlayerProgress(int numberOfLevels){
        SaveSystem.DeleteProgress(numberOfLevels);
    }

}
