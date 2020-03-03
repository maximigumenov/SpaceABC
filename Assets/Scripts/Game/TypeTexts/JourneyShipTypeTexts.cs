using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Типы, которые можно использовать в свободном режиме
/// </summary>
public static class JourneyShipTypeTexts
{
    private static List<string> listType = new List<string>();

    static JourneyShipTypeTexts()
    {
        listType.Add("JourneyMove");
        listType.Add("JourneyWork");
        listType.Add("JourneyExploration");
    }

    public static List<string> GetTypeList() {
        return listType;
    }
}
