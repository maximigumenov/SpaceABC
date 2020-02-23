using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using LocalizationSpace;

public class MainConvertData1
{
    [MenuItem("Tools/ParsedTextData")]
    public static void CreateAsset()
    {
        DataText();
    }

    //Specify name class for Localization
    //
    //The path to the JSON - file 
    //Path save folder
    //Data localization file
    //Name file
    static void DataText()
    {
        ControllCreateAsset.CreateAsset<GameTextData>("Assets/TextData/JourneyMove_ENG.json", "Resources/TextData", "textData", "JourneyMove_ENG");
    }

}
