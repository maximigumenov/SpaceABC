using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;

/// <summary>
/// Получить игровой текст
/// </summary>
public static class GameText
{
    /// <summary>
    /// Текст при ошибке
    /// </summary>
    private static string emptyText = "Empty";



    /// <summary>
    /// Списки текстов с которыми мы работаем
    /// </summary>
    /// <typeparam name="TextDataList">Список</typeparam>
    /// <returns></returns>
    private static List<TextDataList> data = new List<TextDataList>();

    /// <summary>
    /// Список пустых
    /// </summary>
    /// <typeparam name="TextDataList">Список</typeparam>
    /// <returns></returns>
    private static List<TextDataList> dataEmpty = new List<TextDataList>();

    /// <summary>
    /// Проинициализировать пустые
    /// </summary>
    static GameText()
    {
        dataEmpty = new List<TextDataList>();
        TextDataList added = InitDataList(emptyText);
        if (added != null)
        {
            dataEmpty.Add(added);
        }
    }

    /// <summary>
    /// Получить TextDataList
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static TextDataList InitDataList(string path)
    {
        TextDataList result = null;
        GameObject prefab = Resources.Load<GameObject>("TextResources/" + path);
        if (prefab != null)
        {
            
        
        GameObject go = MonoBehaviour.Instantiate(prefab);

        result = go.GetComponent<TextBehaviour>().dataList;
        result.Initialization();
        MonoBehaviour.Destroy(go);
        }
        return result;
    }

    

    /// <summary>
    /// Проинициализировать все списки, которые мы будем использовать в текущий момент
    /// </summary>
    /// <param name="types">Список типов, которые мы будем использовать</param>
    public static void Initialization(List<string> types)
    {
        data = new List<TextDataList>();
        for (int i = 0; i < types.Count; i++)
        {
            TextDataList added = InitDataList(types[i]);
            if (added != null)
            {
                data.Add(added);
            }
        }
    }

    public static void AddType(string type)
    {
        TextDataList added = InitDataList(type);
            if (added != null)
            {
                data.Add(added);
            }
    }

    /// <summary>
    /// Получить текст
    /// </summary>
    /// <param name="type">Тип текста</param>
    /// <returns></returns>
    public static TextData Get(string type)
    {
        TextDataList temp = data.Find(x => x.type == type);
        if (temp == null)
        {
            temp = dataEmpty.Find(x => x.type == emptyText);
        }

        TextData result = temp.Get();
        return result;
    }

    /// <summary>
    /// Получить по тексту, каждого типа
    /// </summary>
    /// <param name="types"></param>
    /// <returns></returns>
    public static List<TextData> GetOneType(List<string> types)
    {
        TextDataList baseTemp = new TextDataList();
        List<TextData> result = new List<TextData>();

        for (int i = 0; i < types.Count; i++)
        {
            TextDataList temp = data.Find(x => x.type == types[i]);

            if (temp == null)
            {
                temp = dataEmpty.Find(x => x.type == emptyText);
            }

            if (i == 0)
            {
                baseTemp = temp;
            }
            else
            {
                baseTemp.data.AddRange(temp.CopyList());
            }
        }

        for (int i = 0; i < types.Count; i++)
        {
            TextData tempTextData = baseTemp.Get();
            string typeClear = tempTextData.type;
            baseTemp.ClearThisType(typeClear);
            result.Add(tempTextData);
        }


        return result;
    }
}