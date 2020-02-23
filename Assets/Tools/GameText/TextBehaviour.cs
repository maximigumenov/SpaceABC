using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;

public class TextBehaviour : MonoBehaviour
{
    public TextDataList dataList;

    [ContextMenu("Convert")]
    public void Convert() {
        GameTextData gameTextData = Resources.Load<GameTextData>("TextData/" + dataList.type);
        Debug.LogError(gameTextData.textData.Length);
        dataList.data = new List<TextData>();

        for (int i = 0; i < gameTextData.textData.Length; i++)
        {
            TextData temp = new TextData(gameTextData.textData[i].text, dataList);
            dataList.data.Add(temp);
        }

    }
}
