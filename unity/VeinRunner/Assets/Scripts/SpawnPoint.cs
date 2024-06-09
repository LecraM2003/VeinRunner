using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    bool locked = false;

    int locked_for = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.locked)
        {
            if (this.locked_for >= 30)
            {
                this.locked = false;
                this.locked_for = 0;
            }
            else
            {
                this.locked_for++;
            }
        }
    }

    public void lockPoint()
    {
        this.locked = true;
        this.locked_for = 0;
    }

    public bool isLocked()
    {
        return this.locked;
    }

}
