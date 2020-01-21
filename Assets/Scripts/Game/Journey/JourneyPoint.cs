using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using System;
using MoveSpace;
using GameTextSpace;

public class JourneyPoint : MonoBehaviour
{
    public JourneyPointData data = new JourneyPointData();

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    public float Distance { get { return GetDistance(); } }

    private void Initialization()
    {
        data.Initialization(this);
    }

    private void Generate() {

    }


    public void ShowData() {
        GameObject prefab = Load.Prefab.Get("TestObject");
        Instantiate(prefab, transform);
    }
    

    private float GetDistance() {
        float result = 0;

        if (ShipJourney.ShipTransform != null)
        {
            result = Vector3.Distance(ShipJourney.ShipTransform.position, transform.position);
        }

        return result;
    }
}

public class JourneyPointData {
    public Action OnStartMove;
    public Action OnEndMove;

    public string typeMessage;
    public string message;
    private Transform transformMain;
    private JourneyPoint journeyPoint;

    public void Initialization(JourneyPoint journeyPoint) {
        this.journeyPoint = journeyPoint;
        typeMessage = "JourneyMove_ENG";
        transformMain = journeyPoint.transform;
    }

    public void ActiveName() {

        Action Stop = () => {
            journeyPoint.ShowData();
        };

        Action<string> Change = (str) => {
            Debug.LogError(str);
        };

        Action Good = () => {
            EnterTextController.RemoveAll();
            MoveManager.Add(ShipJourney.ShipTransform, transformMain, 10, 10, 3f, Stop);
            OnStartMove?.Invoke();
        };

        Action Bed = () => {
            
        };
        message = GameText.Get(typeMessage).text;
        EnterTextController.Add(message, Change, Good, Bed);

    }
}
