using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MoveSpace
{
    public static class MoveManager
    {
        /// <summary>Работа с движениями</summary>
        public static MoveWork work = new MoveWork();
        /// <summary>Взаимоотношения</summary>
        public static List<MoveRelationship> relationships = new List<MoveRelationship>();
        /// <summary>Объект, создающийся на сцене и отвечающий за все передвижения</summary>
        private static ControllerObject controller;

        /// <summary>
        /// Инициализировать менеджер
        /// </summary>
        static MoveManager()
        {
            CreateController();
        }

        /// <summary>
        /// Добавить отношение движения между данными объектами с соответствующими параметрами
        /// </summary>
        /// <param name="_transform"></param>
        /// <param name="_target"></param>
        /// <param name="_speedMove"></param>
        /// <param name="_speedRotate"></param>
        /// <param name="_minDistance"></param>
        public static void Add(Transform _transform, Transform _target, float _speedMove, float _speedRotate, float _minDistance)
        {
            Stop(_transform, _target);
            relationships.Add(new MoveRelationship(_transform, _target, _speedMove, _speedRotate, _minDistance));
        }

        /// <summary>
        /// Остановить движение между данными объектами
        /// </summary>
        /// <param name="_transform"></param>
        /// <param name="_target"></param>
        public static void Stop(Transform _transform, Transform _target)
        {
            List<MoveRelationship> finded = Find(_transform, _target);

            for (int i = 0; i < finded.Count; i++)
            {
                relationships.Remove(finded[i]);
            }

        }

        /// <summary>
        /// Вернуть все взаимоотношения, отвечающие за указанные объекты
        /// </summary>
        /// <param name="_transform"></param>
        /// <param name="_target"></param>
        /// <returns></returns>
        private static List<MoveRelationship> Find(Transform _transform, Transform _target)
        {
            List<MoveRelationship> result = relationships.FindAll(x => x.transform == _transform && x.target == _target);

            return result;
        }

        /// <summary>
        /// Создать контроллер для движения
        /// </summary>
        private static void CreateController()
        {
            GameObject go = new GameObject("MoveBehaviour");
            go.AddComponent(typeof(ControllerObject));
            controller = go.GetComponent<ControllerObject>();
        }

        /// <summary>
        /// Объект, создающийся на сцене и отвечающий за все передвижения
        /// </summary>
        public class ControllerObject : MonoBehaviour
        {
            private void Update()
            {
                Move();
            }

            /// <summary>
            /// Движение между всеми объектами
            /// </summary>
            private void Move()
            {
                for (int i = 0; i < MoveManager.relationships.Count; i++)
                {
                    MoveManager.relationships[i].Move();
                }
            }
        }
    }
}
