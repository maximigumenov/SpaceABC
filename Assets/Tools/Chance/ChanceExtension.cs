using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс для всех данных, получаемых по шансу
/// </summary>
public interface IRandom
{
    /// <summary>
    /// Шанс выпадания
    /// </summary>
    float returnChance { get; }
}


public static class ChanceExtension
{
    private static System.Random _r = new System.Random();

    /// <summary>
    /// Случайный объект списка
    /// </summary>
    /// <param name="list">Список</param>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <returns></returns>
    public static T Random<T>(this List<T> list)
    {
        var val = list[UnityEngine.Random.Range(0, list.Count)];
        return val;
    }

    /// <summary>
    /// Случайный объект списка с определенной вероятностью
    /// </summary>
    /// <param name="vals">Список</param>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <returns></returns>
    public static T RandomByChance<T>(this List<T> vals) where T : IRandom
    {
        var total = 0f;

        var probs = new float[vals.Count];

        for (int i = 0; i < probs.Length; i++)
        {
            probs[i] = vals[i].returnChance;
            total += probs[i];
        }

        var randomPoint = (float)_r.NextDouble() * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return vals[i];
            }
            randomPoint -= probs[i];
        }

        return vals[0];

    }
}


