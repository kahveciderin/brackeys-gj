using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{

    public GameObject mainButtons;
    public GameObject levelSelection;
    public GameObject settings;

    public Text levelDisplay;



    public static int levelNo = 1;

    public void StartPressed(){
         mainButtons.SetActive(false);
         levelSelection.SetActive(true);

    }

    public void SettingsPressed(){
        mainButtons.SetActive(false);
        settings.SetActive(true);

    }

    public void StartGame(){
        PlayerPrefs.SetInt("levelToLoad", levelNo - 1);
        SceneManager.LoadScene(1);
    }

    public void BackPressed(){

        mainButtons.SetActive(true);
        levelSelection.SetActive(false);
        settings.SetActive(false);
    }

    public void increase(int amount){
        levelNo += amount;
        if(levelNo < 1) levelNo = 1;
        if(levelNo > 2147483647) levelNo = 2147483647;
        levelDisplay.text =levelNo.ToString();
    }
}
