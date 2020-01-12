using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Менеджер аудио.
    /// </summary>
    /// <typeparam name="AudioClip">Клип из ресурсов</typeparam>
    public class LoadSound : ILoadFile<AudioClip>
    {
        /// <summary>
        /// Путь к префабу содержащего все клипы.
        /// </summary>
        private string path = "SystemPrefabs/Sound";

        /// <summary>
        /// Список клипов и ID
        /// </summary>
        /// <value></value>
        public Dictionary<string, ILoadContent<AudioClip>> data { get; set; }

        /// <summary>
        /// Загрузить префаб с клипами.
        /// </summary>
        public LoadSound()
        {
            Initialization();
        }

        /// <summary>
        /// Загрузить префаб с клипами.
        /// </summary>
        public void Initialization()
        {
            ILoadPrefab<AudioClip> prefabData = Resources.Load<SoundPrefab>(path);
            data = prefabData.GetDictionary();
        }

        /// <summary>
        /// Получить клип по ID
        /// </summary>
        /// <param name="_id">ID клипа</param>
        /// <returns></returns>
        public AudioClip Get(string _id)
        {
            AudioClip result = null;

            ILoadContent<AudioClip> finded = data[_id];
            if (finded != null)
            {
                finded.loaded = Resources.Load<AudioClip>(finded.path) ?? finded.loaded;
                result = finded.loaded;
            }

            return result;
        }
    }
}
