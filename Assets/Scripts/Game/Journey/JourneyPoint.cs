﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using System;
using MoveSpace;
using GameTextSpace;

public class JourneyPoint : MonoBehaviour
{
    public JourneyPointData data = new JourneyPointData();
    public string namePrefab = "TestObject";

    private IJourneyObject journeyObject;

    public Transform cameraPosition { get { return journeyObject.cameraPosition; } }
    public Transform cameraView { get { return journeyObject.cameraView; } }

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
        GameObject prefab = Load.Prefab.Get(namePrefab);
        journeyObject = Instantiate(prefab, transform).GetComponent<IJourneyObject>();
        data.isActive = true;
    }

    public void ShowText()
    {
        journeyObject.SetTextUi();
    }

    public void ClearData() {

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

//public class JourneyPointData {
//    public Action OnStartMove;
//    public Action OnEndMove;

//    public bool isActive = false;

//    public string typeMessage;
//    public string message;
//    private Transform transformMain;
//    private JourneyPoint journeyPoint;
//    private JourneyTargetText journeyTargetText;

//    public void Initialization(JourneyPoint journeyPoint) {
//        this.journeyPoint = journeyPoint;
//        typeMessage = "JourneyMove_ENG";
//        transformMain = journeyPoint.transform;
//    }

//    public void ActiveName(JourneyTargetText _journeyTargetText) {
//        journeyTargetText = _journeyTargetText;
//        journeyTargetText.SetText(message.GetColor(journeyTargetText.notSelectColor));
//        Action Stop = () => {
//            ShipCamera.moveTransform = journeyPoint.cameraPosition;
//            ShipCamera.rotateTransform = journeyPoint.cameraView;
//        };

//        Action<string> Change = (str) => {
//            journeyTargetText.SetText(message.GetColor(str, journeyTargetText.selectColor, journeyTargetText.notSelectColor));
//        };

//        Action Good = () => {
//            journeyPoint.ShowData();
//            EnterTextController.RemoveAll();
//            MoveManager.Add(ShipJourney.ShipTransform, transformMain, 10, 10, 3f, Stop);
//            OnStartMove?.Invoke();
//        };

//        Action Bed = () => {
//            journeyTargetText.SetText(message.GetColor(journeyTargetText.notSelectColor));
//        };
//        message = GameText.Get(typeMessage).text;
//        EnterTextController.Add(message, Change, Good, Bed);

//    }
//}
