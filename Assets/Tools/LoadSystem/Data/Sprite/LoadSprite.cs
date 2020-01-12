using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Менеджер спрайтов.
    /// </summary>
    /// <typeparam name="Sprite">Спрайт из ресурсов</typeparam>
    public class LoadSprite : ILoadFile<Sprite>
    {
        /// <summary>
        /// Путь к префабу содержащего все спрайты.
        /// </summary>
        private string path = "SystemPrefabs/Sprite";

        /// <summary>
        /// Список спрайтов и ID
        /// </summary>
        /// <value></value>
        public Dictionary<string, ILoadContent<Sprite>> data { get; set; }
        //public List<IPreloadData<Sprite>> data { get; set; }

        /// <summary>
        /// Загрузить префаб со спрайтами.
        /// </summary>
        public LoadSprite()
        {
            Initialization();
        }

        /// <summary>
        /// Загрузить префаб со спрайтами.
        /// </summary>
        public void Initialization()
        {
            ILoadPrefab<Sprite> prefabData = Resources.Load<SpritePrefab>(path);
            data = prefabData.GetDictionary();
        }

        /// <summary>
        /// Получить спрайт по ID
        /// </summary>
        /// <param name="_id">ID спрайта</param>
        /// <returns></returns>
        public Sprite Get(string _id)
        {
            Sprite result = null;

            ILoadContent<Sprite> finded = data[_id];
            if (finded != null)
            {
                finded.loaded = Resources.Load<Sprite>(finded.path) ?? finded.loaded;
                result = finded.loaded;
            }

            return result;
        }
    }
}
