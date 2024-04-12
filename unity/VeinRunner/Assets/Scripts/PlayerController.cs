using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private float startXPos;
    // Start is called before the first frame update
    void Start()
    {
        startXPos = transform.position.x;
        curHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != targetPos.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow)) && curX < maxX)
            {
                curX++;
                targetPos = new Vector2(transform.position.x + XIncrement, transform.position.y);

            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow)) && curX > minX)
            {
                curX--;
                targetPos = new Vector2(transform.position.x - XIncrement, transform.position.y);
            }
        }
    }

    /// <summary>
    /// Adds the given health to the players current health
    /// </summary>
    /// <param name="health">health which will get added</param>
    public void AddHealth(int health)
    {
        curHealth += health;
    }

    /// <summary>
    /// Removes the given health from the players current health
    /// </summary>
    /// <param name="health">Health which get removed</param>
    public void RemoveHealth(int health) 
    {
        curHealth -= health;
    }
}
