using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveSpace
{
    /// <summary>
    /// Работа с движениями
    /// </summary>
    public class MoveWork
    {
        /// <summary>
        /// Развернуть объект к цели
        /// </summary>
        /// <param name="transform">Основной объект</param>
        /// <param name="target">Цель</param>
        /// <param name="speed">Скорость поворота</param>
        public void RotateTo(Transform transform, Transform target, float speed = 0.01f)
        {
            Vector3 targetDir = target.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        /// <summary>
        /// Двигать объект к цели
        /// </summary>
        /// <param name="transform">Основной объект</param>
        /// <param name="target">Цель</param>
        /// <param name="speed">Скорость движения</param>
        public void MoveTo(Transform transform, Transform target, float speed = 0.01f)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }


        /// <summary>
        /// Вернуть true если не достигли определенной дистанции до цели
        /// </summary>
        /// <param name="transform">Основной объект</param>
        /// <param name="target">Цель</param>
        /// <param name="min">Минимальное допустимое растояние</param>
        /// <returns></returns>
        public bool IsDistance(Transform transform, Transform target, float min = 0)
        {
            return Vector3.Distance(transform.position, target.position) > min;
        }
    }
}
