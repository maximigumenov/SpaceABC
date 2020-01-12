using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using LocalizationSpace;

public class ParsedLocalization  {


	[MenuItem("Tools/ParsedLocalization")]
	public static void CreateAsset ()
	{
		DataLocalization ();
	}

	//Specify name class for Localization
	//
	//The path to the JSON - file 
	//Path save folder
	//Data localization file
	//Name file
	static void DataLocalization(){
		ControllCreateAsset.CreateAsset<Language> ("Assets/Lang/RU.json","LocalizationFiles", "langData", "RU");
		ControllCreateAsset.CreateAsset<Language> ("Assets/Lang/EN.json","LocalizationFiles", "langData", "EN");
	}


}

