using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float speed = 15;
    public int increase = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); //move object every time

        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //if collision to player happens
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().AddBonus(increase); //
            Destroy(gameObject); //destroy itself (obstacle)
           // curBonus += bonus;   --> das war eigentlich drin, aber warum?
        }
    }

}
