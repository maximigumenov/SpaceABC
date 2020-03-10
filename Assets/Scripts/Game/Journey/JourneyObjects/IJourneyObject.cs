using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJourneyObject 
{
    List<string> types { get; set; }
    Transform cameraPosition { get; }
    Transform cameraView { get; }

    /// <summary>
    /// Вывести текст с выбором
    /// </summary>
    void SetTextUi();
    /// <summary>
    /// Получить типы, которые мы не используем
    /// </summary>
    /// <param name="notActiveType">Типы, которые мы не используем</param>
    void Sort(out List<string> notActiveType);
    /// <summary>
    /// Вызывается при каждом изминении текста
    /// </summary>
    /// <param name="message"></param>
    /// <param name="_text"></param>
    /// <param name="textJourney"></param>
    void WorkChange(string message, string _text, TextJourneyObject textJourney);
    void WorkGood(TextJourneyObject textJourney);
    void WorkBed(string message, TextJourneyObject textJourney);
}
