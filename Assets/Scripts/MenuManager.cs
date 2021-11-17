using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, settingsMenu, selectionMenu;
    [SerializeField] private List<string> scenes;
    public void SettingsButtonClicked(){
        mainMenu.SetActive(false);
        selectionMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void BackButtonClicked(){
        settingsMenu.SetActive(false);
        selectionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void StartButtonClicked(){
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        selectionMenu.SetActive(true);

    }
    public void LoadLevel(int levelId){
        SceneManager.LoadScene(scenes[levelId]);
    }
}
