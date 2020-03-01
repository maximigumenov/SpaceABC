using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;
using System;
using EnterTextSpace;
using MoveSpace;

public class TestJourneyObject : MonoBehaviour, IJourneyObject
{
    public Transform _cameraPosition;
    public Transform _cameraView;


    public List<string> _types;



    public List<string> types
    {
        get
        {
            return _types;
        }

        set
        {
            _types = value;
        }
    }

    public Transform cameraPosition {get {return _cameraPosition; }}
    public Transform cameraView { get { return _cameraView; } }


    MoveWork moveWork = new MoveWork();

    void Start() {
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        ClearData();
        GetData();
        Sort();
        SetTextUi();
    }

    public List<TextJourneyObject> listTexts;

    private List<TextData> data = new List<TextData>();

    public void ClearData() {
        EnterTextController.RemoveAll();
    }

    public void GetData() {
        GameText.Initialization(types);
        data = GameText.GetOneType(types);

    }

    public void SetTextUi() {
        for (int i = 0; i < data.Count; i++)
        {
            TextJourneyObject temp = listTexts.Find(x => x.type == data[i].type);
            temp.targetText.SetText(data[i].text.GetColor(temp.targetText.notSelectColor));
            SetWork(data[i].text, data[i].type);
            temp.targetText.gameObject.SetActive(true);
        }
    }

    public void Sort() {
        data.Remove(data.Random());
    }

    public void SetWork(string message, string type)
    {
       

        Action<string> Change = (str) => {
            
        };

        Action Good = () => {
            Work(type);
        };

        Action Bed = () => {

        };

        EnterTextController.Add(message, Change, Good, Bed);
    }

    public void ClearObject() {
        
        ShipJourney.ShowMoveTextUI?.Invoke();

        ShipCamera.moveTransform = ShipJourney.CameraTransform;
        ShipCamera.rotateTransform = ShipJourney.ShipTransform;

        Destroy(this.gameObject);
    }

    public void Work(string type) {
        ClearObject();
    }
}


