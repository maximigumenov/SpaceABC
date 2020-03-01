using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;
using System;
using EnterTextSpace;
using MoveSpace;

public class BaseJourney : MonoBehaviour, IJourneyObject
{
    public Transform _cameraPosition;
    public Transform _cameraView;
    public List<string> _types;
    public List<string> types { get { return _types; } set { _types = value; } }

    public Transform cameraPosition { get { return _cameraPosition; } }
    public Transform cameraView { get { return _cameraView; } }

    protected MoveWork moveWork = new MoveWork();

    public List<TextJourneyObject> listTexts;

    private List<TextData> data = new List<TextData>();

    public virtual void Start() {
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);

        ClearData();
        GetData();
        Sort();
        SetTextUi();
    }

    /// <summary>
    /// Очистить текст
    /// </summary>
    protected void ClearData()
    {
        EnterTextController.RemoveAll();
    }

    public void Sort()
    {
        data.Remove(data.Random());
    }

    public virtual void GetData()
    {
        GameText.Initialization(types);
        data = GameText.GetOneType(types);

    }

    public virtual void SetTextUi()
    {
        for (int i = 0; i < data.Count; i++)
        {
            TextJourneyObject temp = listTexts.Find(x => x.type == data[i].type);
            temp.targetText.SetText(data[i].text.GetColor(temp.targetText.notSelectColor));
            SetWork(data[i].text, data[i].type);
            temp.targetText.gameObject.SetActive(true);
        }
    }

    public virtual void SetWork(string message, string type)
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

    public virtual void ClearObject()
    {

        ShipJourney.ShowMoveTextUI?.Invoke();

        ShipCamera.moveTransform = ShipJourney.CameraTransform;
        ShipCamera.rotateTransform = ShipJourney.ShipTransform;

        Destroy(this.gameObject);
    }


    public virtual void Work(string type)
    {
        ClearObject();
    }

}

[System.Serializable]
public class TextJourneyObject
{
    public string type;
    public JourneyTargetText targetText;
}
