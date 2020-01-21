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
        TestObjects();
    }

    public void TestObjects() {
        for (int i = 0; i < 10000; i++)
        {
            GameText.Initialization(new List<string>(new string[] { "test1", "JourneyMove_ENG" }));
            List<TextData> listData = GameText.GetOneType(new List<string>(new string[] { "test1", "JourneyMove_ENG" }));

            if (!isTestObjects(listData[0], listData[1]))
            {
                Debug.LogError("Problem");
            }
        }
        
    }

    public bool isTestObjects(TextData data1, TextData data2) {

        if (data1.type == data2.type)
        {
            return false;
        }

        if (data1.text[0] == data2.text[0])
        {
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
