using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveSpace
{
    public static class ExtansionForMoveSystem
    {
        /// <summary>
        /// Двигаться к данной цели
        /// </summary>
        /// <param name="transform">Основной объект</param>
        /// <param name="target">Цель</param>
        /// <param name="_minDistance">Минимальное допустимое растояние</param>
        /// <param name="_speedMove">Скорость движения</param>
        /// <param name="_speedRotate">Скорость поворота</param>
        public static void MoveTo(this Transform transform, Transform target, float _minDistance = 0, float _speedMove = 1, float _speedRotate = 5)
        {
            MoveManager.Add(transform, target, _speedMove, _speedRotate, _minDistance);
        }

        /// <summary>
        /// Остановить движение
        /// </summary>
        /// <param name="transform">Основной объект</param>
        /// <param name="target">Цель</param>
        public static void StopMove(this Transform transform, Transform target)
        {
            MoveManager.Stop(transform, target);
        }
    }
}
