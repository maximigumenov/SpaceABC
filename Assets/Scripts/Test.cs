using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using System;
using GameTextSpace;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameText.Initialization(new List<string>(new string[] { "test1", "Empty" }));
        Debug.LogError(GameText.Get("test1"));
        GameText.Initialization(new List<string>(new string[] { "test1", "Empty" }));
        Debug.LogError(GameText.Get("test1"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
