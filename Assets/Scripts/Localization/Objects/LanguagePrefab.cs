using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
public class LanguagePrefab : MonoBehaviour {

	[SerializeField] private Language language;
	private Dictionary<string, string> languages;

		public void InitLanguages(){
			languages = new Dictionary<string, string>();
			for (int i = 0; i < language.langData.Length; i++)
			{
				languages.Add(language.langData[i].key, language.langData[i].value);
			}
		}
	
	
		public string GetText(string _key){
			return languages [_key];
		}

		public int GetTotalWord(){
			return languages.Count;
		}
	
	}


}
