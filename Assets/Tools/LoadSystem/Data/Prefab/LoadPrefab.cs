using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Менеджер префабов.
    /// </summary>
    /// <typeparam name="GameObject">Префаб из ресурсов</typeparam>
    public class LoadPrefab : ILoadFile<GameObject>
    {
        /// <summary>
        /// Путь к префабу содержащего все префабы.
        /// </summary>
        private string path = "SystemPrefabs/Prefab";

        /// <summary>
        /// Список префабов и ID
        /// </summary>
        /// <value></value>
        public Dictionary<string, ILoadContent<GameObject>> data { get; set; }

        /// <summary>
        /// Загрузить префаб с префабами.
        /// </summary>
        public LoadPrefab()
        {
            Initialization();
        }

        /// <summary>
        /// Загрузить префаб с префабами.
        /// </summary>
        public void Initialization()
        {
            ILoadPrefab<GameObject> prefabData = Resources.Load<PrefabPrefab>(path);
            data = prefabData.GetDictionary();
        }

        /// <summary>
        /// Получить префаб по ID
        /// </summary>
        /// <param name="_id">ID префаба</param>
        /// <returns></returns>
        public GameObject Get(string _id)
        {
            GameObject result = null;

            ILoadContent<GameObject> finded = data[_id];
            if (finded != null)
            {
                finded.loaded = Resources.Load<GameObject>(finded.path) ?? finded.loaded;
                result = finded.loaded;
            }
           // result = MonoBehaviour.Instantiate(result);
            return result;
        }
    }
}
