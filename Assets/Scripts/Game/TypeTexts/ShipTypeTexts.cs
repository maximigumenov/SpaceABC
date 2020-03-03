using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Типы, которые содержит игрок и может использовать в игре
/// </summary>
public static class ShipTypeTexts 
{
    private static List<string> listType = new List<string>();
    private static string eng = "_ENG";
    private static string rus = "_RUS";

    static ShipTypeTexts() {
        listType.Add("JourneyMove");
        listType.Add("JourneyWork");
        listType.Add("JourneyExploration");
    }

    public static List<string> GetActiveList(List<string> list)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < list.Count; i++)
        {
            if (listType.Find(x => x == list[i]) != null)
            {
                result.Add(list[i] + eng);
            }
        }

        return result;
    }
}
