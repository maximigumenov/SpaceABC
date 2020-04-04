using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using LocalizationSpace;

public class MainConvertData1
{
    private static string engData = "_ENG";
    private static string rusData = "_RUS";

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
        JourneyData();
    }

    private static void JourneyData() {
        CreateData("JourneyMove");
        CreateData("JourneyWork");
        CreateData("JourneyExploration");
        CreateData("FindAsteroid");
        CreateData("TransitionMetal");
    }

    private static void CreateData(string nameData) {
        ControllCreateAsset.CreateAsset<GameTextData>("Assets/TextData/" + nameData + engData + ".json", "Resources/TextData", "textData", nameData + engData);
        ControllCreateAsset.CreateAsset<GameTextData>("Assets/TextData/" + nameData + rusData + ".json", "Resources/TextData", "textData", nameData + rusData);
    }
}
