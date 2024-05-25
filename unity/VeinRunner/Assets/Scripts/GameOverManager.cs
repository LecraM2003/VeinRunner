using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
