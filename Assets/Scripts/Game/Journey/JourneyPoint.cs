using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using System;
using MoveSpace;

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
        data.Initialization(transform);
    }

    private void Generate() {

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

    public string name;
    private Transform transformMain;

    public void Initialization(Transform transform) {
        name = UnityEngine.Random.Range(1000, 9999).ToString();
        transformMain = transform;
    }

    public void ActiveName() {

        Action Stop = () => {
            Debug.LogError("Test show");
            ShipJourney.ShowTextUI();
        };

        Action<string> Change = (str) => {
            Debug.LogError(str);
        };

        Action Good = () => {
            EnterTextController.RemoveAll();
            MoveManager.Add(ShipJourney.ShipTransform, transformMain, 10, 10, 0.01f, Stop);
            OnStartMove?.Invoke();
        };

        Action Bed = () => {
            
        };

        EnterTextController.Add(name, Change, Good, Bed);

    }
}
