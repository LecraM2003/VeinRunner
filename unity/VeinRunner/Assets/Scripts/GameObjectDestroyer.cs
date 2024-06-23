using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    public int destroyCount;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyCount);
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
