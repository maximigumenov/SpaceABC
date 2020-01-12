using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextColorExtension
{
    /// <summary>
    /// Подкрашиваю цветом совпавший текст
    /// </summary>
    /// <param name="baseText">Основной текст</param>
    /// <param name="testText">Текст для сравнения</param>
    /// <param name="hexSelect">Цвет совпавшего текста</param>
    /// <param name="hexNotSelect">Цвет не совпавшего текста</param>
    /// <returns></returns>
    public static string GetColor(this string baseText, string testText, string hexSelect, string hexNotSelect)
    {
        int literal = FindLiteral(baseText, testText);
        return "<color=#" + hexSelect + ">" + FirstPath(baseText, literal) + "</color>" +
        "<color=#" + hexNotSelect + ">" + SecondPath(baseText, literal) + "</color>";
    }

    /// <summary>
    /// Закрашивает необходимым цветом
    /// </summary>
    /// <param name="baseText">Основной текст</param>
    /// <param name="hexColor">Цвет текста</param>
    /// <returns></returns>
    public static string GetColor(this string baseText, string hexColor)
    {
        return "<color=#" + hexColor + ">" + baseText + "</color>";
    }

    /// <summary>
    /// Первая часть текста
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="lengt">Буква остановки</param>
    /// <returns></returns>
    private static string FirstPath(string text, int lengt)
    {
        string result = string.Empty;

        if (text == null || lengt > text.Length)
        {
            return text;
        }

        result = text.Substring(0, lengt);

        return result;
    }

    /// <summary>
    /// Вторая часть текста
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="lengt">Буква остановки</param>
    /// <returns></returns>
    private static string SecondPath(string text, int lengt)
    {
        string result = string.Empty;

        if (text == null || lengt > text.Length)
        {
            return "";
        }

        result = text.Substring(lengt);

        return result;
    }

    /// <summary>
    /// Найти количество выбранных букв
    /// </summary>
    /// <param name="baseText">Основной текст</param>
    /// <param name="testText">Текст для сравнения</param>
    /// <returns></returns>
    private static int FindLiteral(string baseText, string testText)
    {
        int result = 0;


        if (testText == null || baseText == null || testText.Length > baseText.Length)
        {
            return result;
        }

        string _baseText = baseText.ToUpper();
        string _testText = testText.ToUpper();

        for (int i = 0; i < _testText.Length; i++)
        {
            if (_baseText[i] == _testText[i])
            {
                result++;
            }
            else
            {
                result = 0;
                break;
            }
        }

        return result;
    }
}
