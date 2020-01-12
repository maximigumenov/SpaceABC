using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Объект с ID, путем к ресурсам и загруженым ранее объектом
    /// </summary>
    /// <typeparam name="Sprite"></typeparam>
    [System.Serializable]
    public class PreloadPrefab : IPreloadData<GameObject>
    {
        /// <summary>
        /// ID объекта
        /// </summary>
        /// <value></value>
        public string id { get { return _id; } set { _id = value; } }
        [SerializeField] private string _id;
        /// <summary>
        /// Данные с путем и объектом
        /// </summary>
        /// <value></value>
        public LoadContent<GameObject> content { get { return GetContent(); } }
        [SerializeField] private LoadContentPrefab _content;

        /// <summary>
        /// Получить контент из редактора
        /// </summary>
        /// <returns></returns>
        private LoadContent<GameObject> GetContent()
        {
            LoadContent<GameObject> result = new LoadContent<GameObject>();
            result.loaded = _content.loaded;
            result.path = _content.path;
            return result;
        }
    }
}
