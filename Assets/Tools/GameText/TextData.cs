using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTextSpace
{
    /// <summary>
    /// Данные для одной еденицы текста
    /// </summary>
    [System.Serializable]
    public class TextData
    {
        public TextData() {

        }

        public TextData(string _text, TextDataList _textDataList)
        {
            text = _text;
            type = _textDataList.type;
        }

        /// <summary>Текст</summary>
        public string text;
        [HideInInspector]public string type;
    }
}
