using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Данные с которыми работаем
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILoadContent<T>
    {
        /// <summary>
        /// Путь в ресурсах из которого его можно загрузить.
        /// </summary>
        /// <value></value>
        string path { get; set; }
        /// <summary>
        /// При первой загрузки загружаем в эту переменную, в дальнейшем берем из нее.
        /// </summary>
        /// <value></value>
        T loaded { get; set; }
    }
}
