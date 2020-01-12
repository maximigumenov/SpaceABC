using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Префаб с данными для префабов.
    /// </summary>
    /// <typeparam name="GameObject"></typeparam>
    public class PrefabPrefab : MonoBehaviour, ILoadPrefab<GameObject>
    {
        /// <summary>
        /// Список из объектов и ID
        /// </summary>
        /// <value></value>
        public List<IPreloadData<GameObject>> data { get { return GetData(); } }

        /// <summary>
        /// Заполняется из инспектора
        /// </summary>
        [SerializeField] private List<PreloadPrefab> _data;

        /// <summary>
        /// Служит для того, чтобы конвертировать объекты, наследуемые от IPreloadData 
        /// в интерфейс IPreloadData
        /// </summary>
        /// <returns></returns>
        public List<IPreloadData<GameObject>> GetData()
        {

            List<IPreloadData<GameObject>> result = new List<IPreloadData<GameObject>>();

            for (int i = 0; i < _data.Count; i++)
            {
                result.Add(_data[i]);
            }

            return result;
        }

        /// <summary>
        /// Перенести список с данными в формат Dictionary.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ILoadContent<GameObject>> GetDictionary()
        {
            Dictionary<string, ILoadContent<GameObject>> result = new Dictionary<string, ILoadContent<GameObject>>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(data[i].id, data[i].content);
            }

            return result;
        }
    }
}
