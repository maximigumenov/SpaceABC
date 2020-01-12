using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTextSpace
{
    /// <summary>
    /// Объект, содержащий список текстов
    /// </summary>
    [System.Serializable]
    public class TextDataList
    {
        /// <summary>Тип данного списка</summary>
        public string type;
        /// <summary>Тип резервного списка</summary>
        public string reserveType;
        /// <summary>Список с текстами, которые мы вносим первоначально</summary>
        public List<TextData> data;

        /// <summary>
        /// Тексты, которые мы еще не использовали
        /// </summary>
        /// <typeparam name="TextData"></typeparam>
        /// <returns></returns>
        private List<TextData> active = new List<TextData>();

        /// <summary>
        /// Тексты, которые мы уже используем
        /// </summary>
        /// <typeparam name="TextData"></typeparam>
        /// <returns></returns>
        private List<TextData> notActive = new List<TextData>();

        /// <summary>
        /// Первые буквы, которые мы используем в данный момент
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        private List<string> first = new List<string>();

        /// <summary>
        /// Проинициализировать список
        /// </summary>
        public void Initialization()
        {
            active = data;
        }

        /// <summary>
        /// Получить текст
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            TextData result = null;

            List<TextData> activeList = OnlyActual(first, active);
            //List<TextData> activeList = active;

            if (active.Count > 0)
            {
                result = activeList.Random();
            }
            else
            {
                GameText.AddType(reserveType);
                return GameText.Get(reserveType);
            }


            active.Remove(result);
            first.Add(result.text[0].ToString());
            notActive.Add(result);

            return result.text;
        }

        /// <summary>
        /// Убирает из списка те, начальные буквы которого, уже использовались
        /// </summary>
        /// <param name="_literals"></param>
        /// <param name="_actuals"></param>
        /// <returns></returns>
        public List<TextData> OnlyActual(List<string> _literals, List<TextData> _actuals)
        {
            List<TextData> results = _actuals;

            for (int i = 0; i < _literals.Count; i++)
            {
                results.RemoveAll(x => IsFind(x, _literals[i]));
            }

            return results;
        }

        /// <summary>
        /// Удаляем повторения
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="liter"></param>
        /// <returns></returns>
        private bool IsFind(TextData _data, string liter)
        {

            if (_data.text != null && _data.text.Length > 0 && _data.text.Substring(0, 1) == liter)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Вернуть текст обратно в спиок
        /// </summary>
        /// <param name="text"></param>
        public void End(string text)
        {
            TextData result = notActive.Find(x => x.text == text);
            string _first = first.Find(x => x == result.text[0].ToString());
            first.Remove(_first);
            active.Add(result);
        }
    }
}
