using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveSpace
{
    /// <summary>
    /// Движение между двумя объектами
    /// </summary>
    public class MoveRelationship
    {
        /// <summary>Основной объект</summary>
        public Transform transform;
        /// <summary>Цель</summary>
        public Transform target;
        /// <summary>Скорость движения</summary>
        float speedMove;
        /// <summary>Скорость поворота</summary>
        float speedRotate;
        /// <summary>Минимальное допустимое растояние</summary>
        float minDistance;

        public System.Action OnStopMove;

        /// <summary>
        /// Задать параметры
        /// </summary>
        /// <param name="_transform">Основной объект</param>
        /// <param name="_target">Цель</param>
        /// <param name="_speedMove">Скорость движения</param>
        /// <param name="_speedRotate">Скорость поворота</param>
        /// <param name="_minDistance">Минимальное допустимое растояние</param>
        public MoveRelationship(Transform _transform, Transform _target, float _speedMove, float _speedRotate, float _minDistance)
        {
            transform = _transform;
            target = _target;
            speedMove = _speedMove;
            speedRotate = _speedRotate;
            minDistance = _minDistance;
        }

        /// <summary>
        /// Задать параметры
        /// </summary>
        /// <param name="_transform">Основной объект</param>
        /// <param name="_target">Цель</param>
        /// <param name="_speedMove">Скорость движения</param>
        /// <param name="_speedRotate">Скорость поворота</param>
        /// <param name="_minDistance">Минимальное допустимое растояние</param>
        /// <param name="OnStop">Действие при остановки</param>
        public MoveRelationship(Transform _transform, Transform _target, float _speedMove, float _speedRotate, float _minDistance, System.Action OnStop)
        {
            transform = _transform;
            target = _target;
            speedMove = _speedMove;
            speedRotate = _speedRotate;
            minDistance = _minDistance;
            OnStopMove = OnStop;
        }

        /// <summary>
        /// Движение между объектами
        /// </summary>
        public void Move()
        {
            if (MoveManager.work.IsDistance(transform, target, minDistance))
            {
                MoveManager.work.RotateTo(transform, target, speedRotate);
                MoveManager.work.MoveTo(transform, target, speedMove);
            }
            else
            {
                MoveManager.Stop(transform, target);
            }
        }
    }
}
