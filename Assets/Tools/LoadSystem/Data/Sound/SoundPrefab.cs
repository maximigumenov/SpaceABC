using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Префаб с данными для клипов.
    /// </summary>
    /// <typeparam name="AudioClip"></typeparam>
    public class SoundPrefab : MonoBehaviour, ILoadPrefab<AudioClip>
    {
        /// <summary>
        /// Список из объектов и ID
        /// </summary>
        /// <value></value>
        public List<IPreloadData<AudioClip>> data { get { return GetData(); } }

        /// <summary>
        /// Заполняется из инспектора
        /// </summary>
        [SerializeField] private List<PreloadSound> _data;

        /// <summary>
        /// Служит для того, чтобы конвертировать объекты, наследуемые от IPreloadData 
        /// в интерфейс IPreloadData
        /// </summary>
        /// <returns></returns>
        public List<IPreloadData<AudioClip>> GetData()
        {

            List<IPreloadData<AudioClip>> result = new List<IPreloadData<AudioClip>>();

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
        public Dictionary<string, ILoadContent<AudioClip>> GetDictionary()
        {
            Dictionary<string, ILoadContent<AudioClip>> result = new Dictionary<string, ILoadContent<AudioClip>>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(data[i].id, data[i].content);
            }

            return result;
        }
    }
}
