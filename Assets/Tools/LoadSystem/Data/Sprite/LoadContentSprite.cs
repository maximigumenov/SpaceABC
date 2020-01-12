using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    /// <summary>
    /// Данные с путем и объектом (Заполняется в редакторе).
    /// </summary>
    /// <typeparam name="Sprite"></typeparam>
    [System.Serializable]
    public class LoadContentSprite : ILoadContent<Sprite>
    {
        /// Путь в ресурсах из которого его можно загрузить.
        /// </summary>
        /// <value></value>
        public string path { get { return _path; } set { _path = value; } }
        [SerializeField] private string _path;
        /// <summary>
        /// При первой загрузки загружаем в эту переменную, в дальнейшем берем из нее.
        /// </summary>
        /// <value></value>
        public Sprite loaded { get { return _loaded; } set { _loaded = value; } }
        [SerializeField] private Sprite _loaded;
    }
}
