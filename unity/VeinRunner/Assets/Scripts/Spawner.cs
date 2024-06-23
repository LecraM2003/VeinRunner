using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoints;

    public GameObject obstacleObject;

    public GameObject bonusObject;

    int obstacle_curTime;

    int bonus_curTime;

    int how_many = 0;

    int how_many_done = 0;

    int force_lane = -1;

    // int frame_counter = 0;


    void Start()
    {
        obstacle_curTime = 0;
        bonus_curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.spawnGameObject(obstacleObject, ref obstacle_curTime, 60, 85);

        if (how_many == 0)
        {
            how_many = Random.Range(1, 5);
        }
        this.spawnGameObject(bonusObject, ref bonus_curTime, 20, 50, true);

        // frame_counter++;
    }

    void spawnGameObject(GameObject gameObject, ref int cur_time, int mindelay, int min_chance, bool multi = false)
    {
        cur_time++;

        bool first_or_single = true;
        if (multi && how_many_done >= 1)
        {
            // decrease vertical gap within groups
            mindelay = 40;
            // must spawn next in group
            min_chance = 101;

            first_or_single = false;
        }

        if (cur_time >= mindelay)
        {
            int randShouldSpawn = Random.Range(1, 100);

            if (randShouldSpawn < min_chance)
            {
                GameObject spawnPoint;
                int tries = 0;      // safety pin to prevent deadlocks
                int randSpawnpoint = -1;
                do
                {
                    /*
                    if (tries > 0)
                    {
                        Debug.Log("lane " + randSpawnpoint + " locked, retry #" + tries + " (frame " + frame_counter + ")");
                    }
                    */

                    if (multi && force_lane > -1)
                    {
                        // forced lane active
                        randSpawnpoint = force_lane;
                    }
                    else
                    {
                        // find new lane
                        randSpawnpoint = Random.Range(0, spawnPoints.transform.childCount);
                    }

                    // Debug.Log("trying to spawn " + d_type + " on lane " + randSpawnpoint + (multi && how_many_done >= 1 ? " (existing group)" : "") + " (frame " + frame_counter + ")");

                    spawnPoint = spawnPoints.transform.GetChild(randSpawnpoint).gameObject;
                    // spawnPoint.GetComponent<SpawnPoint>().sp_id = randSpawnpoint;
                    tries++;
                }
                while (
                    first_or_single
                    && spawnPoint.GetComponent<SpawnPoint>().isLocked()
                    && tries < 20
                );

                spawnPoint.GetComponent<SpawnPoint>().lockPoint();

                if (multi && how_many > 1 && how_many_done == 0)
                {
                    // first of a group
                    force_lane = randSpawnpoint;
                }

                if (multi)
                {
                    how_many_done++;

                    if (how_many_done >= how_many)
                    {
                        how_many = 0;
                        how_many_done = 0;
                        force_lane = -1;
                    }
                }

                Instantiate(gameObject, spawnPoint.transform.position, Quaternion.identity); //create that obstacle
            }

            cur_time = 0;
        }
    }

}
