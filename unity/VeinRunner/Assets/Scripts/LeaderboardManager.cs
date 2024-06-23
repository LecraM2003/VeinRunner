using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{

    public GameObject boardTextObject;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ClearLeaderboard()
    {
        PlayerPrefs.DeleteAll();
        boardTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        boardTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        for (int i = 0; i < 10; i++)
        {
            // load stored score data
            string p_name = PlayerPrefs.GetString("score_name_" + i);
            int p_score = PlayerPrefs.GetInt("score_points_" + i);
            if (string.IsNullOrEmpty(p_name) && p_score == 0)
            {
                // empty slot
                continue;
            }
            // print line on board
            boardTextObject.GetComponent<TMPro.TextMeshProUGUI>().text += p_name + ": " + p_score + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
