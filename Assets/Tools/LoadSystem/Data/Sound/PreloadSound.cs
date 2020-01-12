using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Объект с ID, путем к ресурсам и загруженым ранее объектом
    /// </summary>
    /// <typeparam name="AudioClip"></typeparam>
    [System.Serializable]
    public class PreloadSound : IPreloadData<AudioClip>
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
        public LoadContent<AudioClip> content { get { return GetContent(); } }
        [SerializeField] private LoadContentSound _content;

        /// <summary>
        /// Получить контент из редактора
        /// </summary>
        /// <returns></returns>
        private LoadContent<AudioClip> GetContent()
        {
            LoadContent<AudioClip> result = new LoadContent<AudioClip>();
            result.loaded = _content.loaded;
            result.path = _content.path;
            return result;
        }
    }
}
