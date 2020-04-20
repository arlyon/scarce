using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour, IConsumer
{
    public Collider entry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Give(GameObject obj)
    {
        Destroy(obj);
        return true;
    }
}
