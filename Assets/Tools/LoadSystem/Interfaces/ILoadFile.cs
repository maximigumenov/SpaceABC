using System.Collections.Generic;

namespace LoadSystem
{
    /// <summary>
    /// Объект содержит список и возвращает данные.
    /// </summary>
    /// <typeparam name="T">Тип объекта с которым работаем</typeparam>
    public interface ILoadFile<T>
    {
        /// <summary>
        /// Список из объектов и ID
        /// </summary>
        /// <value></value>
        Dictionary<string, ILoadContent<T>> data { get; set; }

        /// <summary>
        /// Загрузить из ресурсов объект со списком и скопировать данные в data
        /// </summary>
        void Initialization();

        /// <summary>
        /// Вернуть объект по его ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        T Get(string _id);
    }
}
