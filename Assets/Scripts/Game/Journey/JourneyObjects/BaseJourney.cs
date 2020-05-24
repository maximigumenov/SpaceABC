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
    [HideInInspector] public List<string> _types;
    public List<string> types { get { return _types; } set { _types = value; } }

    public Transform cameraPosition { get { return _cameraPosition; } }
    public Transform cameraView { get { return _cameraView; } }

    protected MoveWork moveWork = new MoveWork();

    public List<TextJourneyObject> listTexts;

    [HideInInspector] public List<TextData> data = new List<TextData>();

    public virtual void Start() {
        _types = new List<string>();

        for (int i = 0; i < listTexts.Count; i++)
        {
            _types.Add(listTexts[i].type);
        }

        Debug.LogWarning("Развернуть объект приключения к кораблю");
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);
        moveWork.RotateTo(transform, ShipJourney.ShipTransform, 100);

        ClearData();
        GetData();
        JourneyPhase.EffectFinish += EndAnim;
    }

    

    public virtual void Sort(out List<string> notActiveType)
    {
        Debug.LogWarning("Сортировать данные, чтобы показать те елементы, с которыми можно взаимодействовать и ввернуть те, которые надо выключить");
        notActiveType = new List<string>();
    }

    

    public virtual void SetTextUi()
    {
        List<TextJourneyObject> texts = new List<TextJourneyObject>();
        Debug.LogWarning("Инициализировать данные для елементов с текстом");
        for (int i = 0; i < data.Count; i++)
        {
                TextJourneyObject temp = listTexts.Find(x => x.type == data[i].type);
                temp.targetText.SetText(data[i].text.GetColor(temp.targetText.notSelectColor));
                SetWork(data[i].text, data[i].type, temp);
                temp.targetText.gameObject.SetActive(true);
            texts.Add(temp);
        }

        List<string> notActiveType = new List<string>();

        Sort(out notActiveType);

        Debug.LogWarning("Выключить необходимые елементы");
        for (int i = 0; i < notActiveType.Count; i++)
        {
            TextJourneyObject temp = listTexts.Find(x => x.type == notActiveType[i]);
            if (temp != null)
            {
                temp.targetText.gameObject.SetActive(false);
            }
        }
    }

    

    public virtual void WorkChange(string message, string _text, TextJourneyObject textJourney) {

        textJourney.targetText.SetText(message.GetColor(_text, textJourney.targetText.selectColor, textJourney.targetText.notSelectColor));
    }

    public virtual void WorkGood(TextJourneyObject textJourney)
    {
        EnterTextController.RemoveAll();
        if (textJourney.effect != null)
        {
            textJourney.effect.Show();
        }
        ClearUI();
    }

    

    public void EndAnim(){
        ClearObject();
        CallShip();
        CallShipUI();
    }

    public virtual void WorkBed(string message, TextJourneyObject textJourney)
    {
        textJourney.targetText.SetText(message.GetColor(textJourney.targetText.notSelectColor));
    }

    #region Protected

    protected void GetData()
    {
        GameText.Initialization(types);
        data = GameText.GetOneType(types);
    }

    protected void SetWork(string message, string type, TextJourneyObject textJourney)
    {


        Action<string> Change = (str) => {
            WorkChange(message, str, textJourney);
        };

        Action Good = () => {
            WorkGood(textJourney);
        };

        Action Bed = () => {
            WorkBed(message, textJourney);
        };

        EnterTextController.Add(message, Change, Good, Bed);
    }

    /// <summary>
    /// Очистить текст
    /// </summary>
    protected void ClearData()
    {
        EnterTextController.RemoveAll();
    }

    protected void ClearUI()
    {
        for (int i = 0; i < listTexts.Count; i++)
        {
            listTexts[i].targetText.gameObject.SetActive(false);
        }
    }

    protected void ClearObject()
    {
        Destroy(this.gameObject);
    }

    protected void CallShip() {
        ShipCamera.moveTransform = ShipJourney.CameraTransform;
        ShipCamera.rotateTransform = ShipJourney.ShipTransform;
    }

    protected void CallShipUI()
    {
        ShipJourney.ShowMoveTextUI?.Invoke();
    }

    #endregion

    private void OnDestroy()
    {
        JourneyPhase.EffectFinish -= EndAnim;
    }
}

[System.Serializable]
public class TextJourneyObject
{
    public string type;
    public JourneyTargetText targetText;
    public BaseEffect effect;
}
