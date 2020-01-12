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
    public class PreloadSprite : IPreloadData<Sprite>
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
        public LoadContent<Sprite> content { get { return GetContent(); } }
        [SerializeField] private LoadContentSprite _content;

        /// <summary>
        /// Получить контент из редактора
        /// </summary>
        /// <returns></returns>
        private LoadContent<Sprite> GetContent()
        {
            LoadContent<Sprite> result = new LoadContent<Sprite>();
            result.loaded = _content.loaded;
            result.path = _content.path;
            return result;
        }
    }
}
