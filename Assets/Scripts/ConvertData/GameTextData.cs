using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTextData : ScriptableObject
{
    public _GameTextData[] textData;
}

[System.Serializable]
public class _GameTextData
{
    public string text;
}
