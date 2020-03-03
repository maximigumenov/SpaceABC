using System;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using MoveSpace;
using GameTextSpace;

public class JourneyPointData
{
    public Action OnStartMove;
    public Action OnEndMove;

    public bool isActive = false;

    public string typeMessage;
    public string message;
    private Transform transformMain;
    private JourneyPoint journeyPoint;
    private JourneyTargetText journeyTargetText;

    public void Initialization(JourneyPoint journeyPoint)
    {
        this.journeyPoint = journeyPoint;
        //typeMessage = "JourneyMove_ENG";
        transformMain = journeyPoint.transform;
    }

    public void ActiveName(JourneyTargetText _journeyTargetText, TextData textData)
    {
        typeMessage = textData.type;
        message = textData.text;
        journeyTargetText = _journeyTargetText;
        journeyTargetText.SetText(message.GetColor(journeyTargetText.notSelectColor));
        Action Stop = () => {
            ShipCamera.moveTransform = journeyPoint.cameraPosition;
            ShipCamera.rotateTransform = journeyPoint.cameraView;
        };

        Action<string> Change = (str) => {
            journeyTargetText.SetText(message.GetColor(str, journeyTargetText.selectColor, journeyTargetText.notSelectColor));
        };

        Action Good = () => {
            journeyPoint.ShowData();
            EnterTextController.RemoveAll();
            MoveManager.Add(ShipJourney.ShipTransform, transformMain, 10, 10, 3f, Stop);
            OnStartMove?.Invoke();
        };

        Action Bed = () => {
            journeyTargetText.SetText(message.GetColor(journeyTargetText.notSelectColor));
        };
        //message = GameText.Get(typeMessage).text;
        message = textData.text;
        EnterTextController.Add(message, Change, Good, Bed);

    }
}
