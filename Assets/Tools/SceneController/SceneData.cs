using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneData : MonoBehaviour
{
    /// <summary>
    /// Имя сцены, в которой находится объект
    /// </summary>
    string MyName { get { return gameObject.scene.name; } }

    private void Awake()
    {
        Subscribe();
    }

    /// <summary>
    /// Перейти на эту сцену и сделать ее активной
    /// </summary>
    /// <param name="nameScene"></param>
    private void ShowData(string nameScene) {
        bool active = nameScene == MyName;
        gameObject.SetActive(active);
        if (active)
        {
            SceneManager.SetActiveScene(gameObject.scene);
        }
    }

    /// <summary>
    /// Перейти на эту сцену и сделать ее активной
    /// </summary>
    /// <param name="nameScene"></param>
    private void SelectData(string nameScene)
    {
        if (nameScene == MyName)
        {
            SceneManager.SetActiveScene(gameObject.scene);
        }
        gameObject.SetActive(nameScene == MyName);
    }


    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        SceneController.OnNewScene += ShowData;
        SceneController.OnSelectScene += SelectData;
        SceneController.AddNameScene(MyName);
    }

    private void Unsubscribe() {
        SceneController.RemoveNameScene(MyName);
        SceneController.OnNewScene -= ShowData;
        SceneController.OnSelectScene -= SelectData;
    }
}
