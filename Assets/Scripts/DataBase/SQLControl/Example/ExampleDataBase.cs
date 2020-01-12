using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLData;

public static class ExampleDataBase
{
    private static DataService dataService;

    public static ExampleEditorTable EditorTable;

    public static void Initialization() {
        //Get Data base.
        dataService = new DataService("Example.db");
        CreateDB();
        EditorTable = new ExampleEditorTable(dataService);

    }

    public static void ClearDB()
    {
        dataService = new DataService("Example.db");
        dataService.CreateDB<ExampleData>(new ExampleData());
    }

    private static void CreateDB() {
        if (PlayerPrefs.GetString("ExampleData", "").Length == 0)
        {
            dataService.CreateDB<ExampleData>(new ExampleData());
            PlayerPrefs.SetString("ExampleData", "true");
        }
    }
}
