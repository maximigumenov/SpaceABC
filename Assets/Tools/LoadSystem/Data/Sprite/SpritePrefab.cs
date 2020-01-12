using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Префаб с данными для спрайтов.
    /// </summary>
    /// <typeparam name="Sprite"></typeparam>
    public class SpritePrefab : MonoBehaviour, ILoadPrefab<Sprite>
    {
        /// <summary>
        /// Список из объектов и ID
        /// </summary>
        /// <value></value>
        public List<IPreloadData<Sprite>> data { get { return GetData(); } }

        /// <summary>
        /// Заполняется из инспектора
        /// </summary>
        [SerializeField] private List<PreloadSprite> _data;

        /// <summary>
        /// Служит для того, чтобы конвертировать объекты, наследуемые от IPreloadData 
        /// в интерфейс IPreloadData
        /// </summary>
        /// <returns></returns>
        public List<IPreloadData<Sprite>> GetData()
        {

            List<IPreloadData<Sprite>> result = new List<IPreloadData<Sprite>>();

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
        public Dictionary<string, ILoadContent<Sprite>> GetDictionary()
        {
            Dictionary<string, ILoadContent<Sprite>> result = new Dictionary<string, ILoadContent<Sprite>>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(data[i].id, data[i].content);
            }

            return result;
        }
    }
}
