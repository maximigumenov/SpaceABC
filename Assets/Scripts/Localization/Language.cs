using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
public class Language : ScriptableObject
{
		public LanguageData[] langData;
}

[System.Serializable]
public class LanguageData
{
    public string key;
    public string value;
	}
}
