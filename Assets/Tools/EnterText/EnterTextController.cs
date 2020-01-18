using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace EnterTextSpace
{
    public static class EnterTextController
    {
        /// <summary>Путь к префабу для ввода текста</summary>
        private static string path = "Prefabs/InputField";
        /// <summary>Текст который мы ввели на сцене</summary>
        public static Action<string> OnCall;
        /// <summary>Сбросить текст на пустое множество</summary>
        public static Action OnClear;
        /// <summary>Проверяем, что хоть один объект сейчас задействован(Проверяется, проиграл, выиграл)</summary>
        public static bool isStep = false;
        /// <summary> Список всех связей для ввода текста</summary>
        private static List<TextDataForEnter> list = new List<TextDataForEnter>();

        /// <summary>
        /// Если на сцене нет объекта для считывания текста, то создаем его
        /// </summary>
        public static void Run()
        {
            CreateTextField();
        }

        /// <summary>
        /// Создаем новую связь для проверки текста
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="ChangeAction">Вызывается при проверки текущего текста</param>
        /// <param name="GoodAction">Вызывается, если текст совпал с введенным на сцене</param>
        /// <param name="BedAction">Вызывается, если при проверки, текст не совпал с введеным</param>
        public static void Add(string text, Action<string> ChangeAction, Action GoodAction, Action BedAction)
        {
            list.Add(new TextDataForEnter(text, ChangeAction, GoodAction, BedAction));
        }

        /// <summary>
        /// Удалить данный текст из списка связей
        /// </summary>
        /// <param name="text">Текст</param>
        public static void Remove(string text)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (text.ToUpper() == list[i].text.ToUpper())
                {
                    list[i].ClearData();
                    list.Remove(list[i]);
                }
            }
        }

        /// <summary>
        /// Удалить все данные
        /// </summary>
        public static void RemoveAll()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Remove(list[i].text);
            }
        }

        /// <summary>
        /// Создать объект для проверки текста на сцене
        /// </summary>
        private static void CreateTextField()
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject GO = MonoBehaviour.Instantiate(prefab);
        }
    }

    /// <summary>
    /// Уникальный объект с текстом, который мы проверяем на действие
    /// </summary>
    public class TextDataForEnter
    {
        /// <summary>Текст для проверки</summary>
        public string text;
        /// <summary>Вызывается при проверки текущего текста</summary>
        private Action<string> ChangeAction;
        /// <summary>Вызывается, если текст совпал с введенным на сцене</summary>
        private Action GoodAction;
        /// <summary>Вызывается, если при проверки, текст не совпал с введеным</summary>
        private Action BedAction;

        /// <summary>
        /// Инициализация объекта с текстом
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="ChangeAction">Вызывается при проверки текущего текста</param>
        /// <param name="GoodAction">Вызывается, если текст совпал с введенным на сцене</param>
        /// <param name="BedAction">Вызывается, если при проверки, текст не совпал с введеным</param>
        public TextDataForEnter(string text, Action<string> ChangeAction, Action GoodAction, Action BedAction)
        {
            this.text = text.ToUpper();
            this.ChangeAction = ChangeAction;
            this.GoodAction = GoodAction;
            this.BedAction = BedAction;

            EnterTextController.OnCall += Check;
        }
        /// <summary>
        /// Проверить текст, который мы ввели на сцене
        /// </summary>
        /// <param name="str">Текст со сцены</param>
        private void Check(string str)
        {
            if (str != null && str.Length > 0)
            {
                if (str == text)
                {
                    Good();
                }
                else
                {
                    string equalsData = "";
                    bool isRemove = false;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == text[i])
                        {
                            equalsData += str[i];
                        }
                        else
                        {
                            isRemove = true;
                            break;
                        }
                    }
                    if (isRemove && str[0] == text[0])
                    {
                        Remove();
                    }
                    else if (!isRemove)
                    {
                        Change(equalsData);
                    }
                }
            }
        }

        /// <summary>
        /// У текста есть ряд совпадений
        /// </summary>
        /// <param name="str"></param>
        private void Change(string str)
        {
            ChangeAction?.Invoke(str);
            EnterTextController.isStep = true;
        }

        /// <summary>
        /// Текст совпал
        /// </summary>
        private void Good()
        {
            GoodAction?.Invoke();
            EnterTextController.OnClear?.Invoke();
            EnterTextController.isStep = true;
        }

        /// <summary>
        /// Первоначально у текста были совпадения, но потом при вводе текста, допустили ошибку
        /// </summary>
        private void Remove()
        {
            BedAction?.Invoke();
            EnterTextController.OnClear?.Invoke();
            EnterTextController.isStep = true;
        }

        /// <summary>
        /// Очистить данные
        /// </summary>
        public void ClearData()
        {
            EnterTextController.OnCall -= Check;
        }
    }
}