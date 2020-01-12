using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Класс отвечает за контроль сцен
/// </summary>
public static class SceneController
{
    /// <summary>
    /// Мы загрузили необходимую сцену
    /// </summary>
    public static Action<string> OnNewScene;
    public static Action<string> OnSelectScene;
    private static List<string> nameActiveScene = new List<string>();
    private static string currentScene = "";

    
    /// <summary>
    /// Перейти на сцену.
    /// </summary>
    /// <param name="nameScene">Название сцены</param>
    /// <param name="lastScene">Сцена, из которой мы вызываем переход</param>
    /// <param name="type">Удалить или заморозить прошлую сцену</param>
    public static void SelectScene(string nameScene, string lastScene, TypeLastScene type) {
        currentScene = SceneManager.GetActiveScene().name;
        if (nameActiveScene.Find(x => x == nameScene) == null)
        {
            Load(nameScene);
        }
        else
        {
            SwitchToScene(nameScene);
        }

        if (type == TypeLastScene.Destroy)
        {
            Debug.LogError("Unload " + lastScene);
            SceneManager.UnloadSceneAsync(lastScene);
        }
    }

    /// <summary>
    /// Загрузить новую сцену
    /// </summary>
    private static void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Additive);
        OnNewScene?.Invoke(nameScene);
    }

    /// <summary>
    /// Переключится на уже существующую сцену
    /// </summary>
    /// <param name="nameScene">Название сцены</param>
    private static void SwitchToScene(string nameScene)
    {
        OnSelectScene?.Invoke(nameScene);
    }

    /// <summary>
    /// Добавить сцену в список существующих сцен
    /// </summary>
    /// <param name="name">Название сцены</param>
    public static void AddNameScene(string name) {
        nameActiveScene.Add(name);
    }

    /// <summary>
    /// Удалить сцену из списка существующих сцен
    /// </summary>
    /// <param name="name"></param>
    public static void RemoveNameScene(string name)
    {
        nameActiveScene.Remove(name);
    }
}

/// <summary>
/// Удалить или заморозить прошлую сцену
/// </summary>
public enum TypeLastScene {
    /// <summary>
    /// Переходя из этой сцены, мы ставим ее на паузу
    /// </summary>
    Wait,
    /// <summary>
    /// Переходя из этой сцены, мы ее удаляем
    /// </summary>
    Destroy
}
