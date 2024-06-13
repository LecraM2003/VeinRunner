using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public TextMeshProUGUI nameInputObject;


   public void StartGame(){
        // start button clicked
        this.SaveName();
        SceneManager.LoadScene(1); 
   }
   public void ExitGame(){
		Application.Quit();
	}

    public void SaveName()
    {
        // get name from text input field
        string playerName = nameInputObject.text;
        // store name for later use (PlayerController.RemoveHealth())
        PlayerPrefs.SetString("PlayerName", playerName);
    }
}
