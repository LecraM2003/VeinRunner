using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoints;

    public GameObject obstacleObject;

    public int mindelay = 500;

    int curTime;

    void Start()
    {
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curTime++;

        if (curTime >= mindelay)
        {
            int randShouldSpawn = Random.Range(1, 100);

            if (randShouldSpawn < 90)
            {


                int randSpawnpoint = Random.Range(0, spawnPoints.transform.childCount);

                GameObject spawnPoint = spawnPoints.transform.GetChild(randSpawnpoint).gameObject;

                Instantiate(obstacleObject, spawnPoint.transform.position, Quaternion.identity); //create that obstacle

            }

            curTime = 0;
        }

    }
}
