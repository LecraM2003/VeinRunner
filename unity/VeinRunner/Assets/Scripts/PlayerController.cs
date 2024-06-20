using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    const int minX = 0;
    const int maxX = 3;
    Vector2 targetPos;

    const int XIncrement = 5;

    public int curX = 0;
    public int movementSpeed = 100;
    public int startHealth = 5;

    public int curHealth;

    public int curBonus;

    private int counter = 0;

    ParticleSystem myParticleSystem;
    ParticleSystem.EmissionModule emissionModule;
    public bool once = true;

    private GameObject healthTextObject;

    private GameObject bonusTextObject;

    private GameObject playerSprite;

    public AudioSource hitSound;
    public AudioSource bonusSound;

    private float startXPos;
    // Start is called before the first frame update
    void Start()
    {
        startXPos = transform.position.x;
        curHealth = startHealth;

        healthTextObject = GameObject.FindGameObjectsWithTag("HealthDisplay")[0];
        bonusTextObject = GameObject.FindGameObjectsWithTag("BonusDisplay")[0];
        playerSprite = GameObject.Find("Player/playerSprite");
        myParticleSystem = GetComponent<ParticleSystem>();
        emissionModule = myParticleSystem.emission;

    }

    // Update is called once per frame
    void Update()
    {
        if (counter != 0) {
            counter--;
            if (counter == 0) {
                var renderer = playerSprite.GetComponent<Renderer>();
                Color customColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                renderer.material.SetColor("_Color", customColor);
                emissionModule.enabled=false;
            }
        }

        if (transform.position.x != targetPos.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
        }
        else
        {
            if ((Input.GetKey(KeyCode.RightArrow)) && curX < maxX)
            {
                curX++;
                targetPos = new Vector2(transform.position.x + XIncrement, transform.position.y);

            }
            else if ((Input.GetKey(KeyCode.LeftArrow)) && curX > minX)
            {
                curX--;
                targetPos = new Vector2(transform.position.x - XIncrement, transform.position.y);
            }
        }
    }

    /// <summary>
    /// Adds the given bonus to the players current bonus
    /// </summary>
    /// <param name="bonus">bonus which will get added</param>
    public void AddBonus(int bonus)
    {
        curBonus += bonus;

        AudioSource newSound = Instantiate(bonusSound);
        newSound.Play();

        bonusTextObject.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + curBonus);
    }

    /// <summary>
    /// Removes the given health from the players current health. Displays the new health and plays the hit sound.
    /// </summary>
    /// <param name="health">Health which get removed</param>
    public void RemoveHealth(int health)
    {
        curHealth -= health;
        hitSound.Play();
        healthTextObject.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + curHealth);
         //Particle System
        
        emissionModule.enabled=true;
        myParticleSystem.Play();
        var renderer = playerSprite.GetComponent<Renderer>();
        Color customColor = new Color(1.0f, 0.1f, 0.1f, 1.0f);
        renderer.material.SetColor("_Color", customColor);
        counter = 100;
        if(curHealth <= 0)
        {
            // load player name - entered in main menu
            string player_name = PlayerPrefs.GetString("PlayerName");
            
            // create datatable for easy sorting
            DataTable dt = new DataTable();
            // define columns
            dt.Columns.Add("player");
            dt.Columns.Add("score");
            // set data type of score column to int
            dt.Columns["score"].DataType = Type.GetType("System.Int32");

            // get already stored data from past games
            for (int i = 0; i < 10; i++)
            {
                DataRow irow = dt.NewRow();
                irow["player"] = PlayerPrefs.GetString("score_name_" + i);
                irow["score"] = PlayerPrefs.GetInt("score_points_" + i);
                dt.Rows.Add(irow);
            }

            // add score of current game
            DataRow row = dt.NewRow();
            row["player"] = player_name;
            row["score"] = curBonus;
            dt.Rows.Add(row);

            // sort by score (descending)
            DataRow[] sorted_rows = dt.Select("", "score DESC");
            // store best 10 scores for later display
            for (int i = 0; i < 10; i++)
            {
                PlayerPrefs.SetString("score_name_" + i, sorted_rows[i]["player"].ToString());
                PlayerPrefs.SetInt("score_points_" + i, Int32.Parse(sorted_rows[i]["score"].ToString()));
            }

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
