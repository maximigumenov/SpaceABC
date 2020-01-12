using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadSystem;

/// <summary>
/// Загрузка объктов из ресурсов.
/// </summary>
public static class Load
{
    /// <summary>
    /// Спрайты.
    /// </summary>
    /// <returns></returns>
    public static LoadSprite Sprite = new LoadSprite();
    /// <summary>
    /// Префабы.
    /// </summary>
    /// <returns></returns>
    public static LoadPrefab Prefab = new LoadPrefab();
}