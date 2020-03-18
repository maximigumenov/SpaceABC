using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveSpace;
using System;

namespace Strategic
{
    [Serializable]
    public class BaseMoveObject 
    {
        public Action OnStop;

        public void MoveToTarget(Transform _transform, Transform _target, float _speedMove, float _speedRotate, float _minDistance) {
            MoveManager.Add(_transform, _target, _speedMove, _speedRotate, _minDistance, OnStop);
        }

        public void StopMoveToTarget(Transform _transform, Transform _target)
        {
            MoveManager.Stop(_transform, _target);
        }
    }
}
