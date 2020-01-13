using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Action<string> ChangeAction = (str) => { Debug.LogError(str); };
        Action GoodAction = () => { Debug.LogError("GoodAction"); };
        Action BedAction = () => { Debug.LogError("BedAction"); EnterTextController.Remove("test"); };

        EnterTextController.Add("test", ChangeAction, GoodAction, BedAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
