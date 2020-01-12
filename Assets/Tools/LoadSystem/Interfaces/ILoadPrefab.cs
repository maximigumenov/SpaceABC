using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Префаб с данными для работы. 
    /// </summary>
    /// <typeparam name="T">Тип объекта с которым работаем</typeparam>
    public interface ILoadPrefab<T>
    {
        /// <summary>
        /// Список из объектов и ID
        /// </summary>
        /// <value></value>
        List<IPreloadData<T>> data { get; }
        /// <summary>
        /// Перенести список с данными в формат Dictionary.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ILoadContent<T>> GetDictionary();
        /// <summary>
        /// Служит для того, чтобы конвертировать объекты, наследуемые от IPreloadData 
        /// в интерфейс IPreloadData
        /// </summary>
        /// <returns></returns>
        List<IPreloadData<T>> GetData();
    }
}