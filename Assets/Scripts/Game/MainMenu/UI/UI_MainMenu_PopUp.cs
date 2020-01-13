using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu_PopUp : MonoBehaviour
{
    public Button nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.onClick.AddListener(ToNextLevel);
    }

    private void ToNextLevel() {
        SceneController.SelectScene("Journey", gameObject.scene.name, TypeLastScene.Wait);
    }
}
