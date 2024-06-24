using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    private bool locked = false;

    private int locked_for = 0;

    // public int sp_id = -1;

    // int frame_counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.locked)
        {
            if (this.locked_for >= 200)
            {
                // Debug.Log("unlocking point " + sp_id);
                this.locked = false;
                this.locked_for = 0;
            }
            else
            {
                this.locked_for++;
            }
        }

        // frame_counter++;
    }

    public bool lockPoint()
    {
        if (this.locked)
        {
            return false;
        }

        // Debug.Log("lane " + sp_id + " is being locked for " + d_type + " (frame " + frame_counter + ")");
        this.locked = true;
        this.locked_for = 0;

        return true;
    }

    public bool isLocked()
    {
        // Debug.Log("lane " + sp_id + " is" + (!this.locked ? " not" : "") + " locked for " + d_type + " (frame " + frame_counter + ")");
        return this.locked;
    }

}
