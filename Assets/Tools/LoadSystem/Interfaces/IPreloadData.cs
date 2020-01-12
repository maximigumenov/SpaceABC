using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Объект с ID, путем к ресурсам и загруженым ранее объектом
    /// </summary>
    /// <typeparam name="T">Тип объекта с которым работаем</typeparam>
    public interface IPreloadData<T>
    {
        /// <summary>
        /// ID объекта
        /// </summary>
        /// <value></value>
        string id { get; set; }
        /// <summary>
        /// Данные с путем и объектом
        /// </summary>
        /// <value></value>
        LoadContent<T> content { get; }
    }
}
