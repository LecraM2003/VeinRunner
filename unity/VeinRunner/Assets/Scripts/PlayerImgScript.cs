using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImgScript : MonoBehaviour
{
    public float amp;
    public float freq;
    private Vector3 initpos;

    void Start()
    {
        initpos = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(initpos.x,  Mathf.Sin(Time.time * freq) * amp + initpos.y, 0);
    }
}
