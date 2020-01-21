using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;
using System;
using EnterTextSpace;

public class TestJourneyObject : MonoBehaviour, IJourneyObject
{
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

    void Start() {
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
            temp.targetText.SetText(data[i].text);
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
            Debug.LogError(str);
        };

        Action Good = () => {
            Work(type);
        };

        Action Bed = () => {

        };

        EnterTextController.Add(message, Change, Good, Bed);
    }

    public void Work(string type) {
        Debug.LogError(type);
    }
}

[System.Serializable]
public class TextJourneyObject {
    public string type;
    public JourneyTargetText targetText;
}
