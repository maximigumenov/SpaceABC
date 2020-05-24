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
        Invoke("TestObjects", 10);
    }

    public void TestObjects() {
       // SceneController.SelectScene("Journey", "SelectMision", TypeLastScene.Destroy);
    }
    

    
}
