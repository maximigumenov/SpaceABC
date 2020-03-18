using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategic
{
    public interface IMoveObject
    {
        BaseMoveObject moveObject { get; set; } 
        float speedMove { get; set; }
        float speedRotate { get; set; }
        float minDistance { get; set; }

        void MoveTo(Transform _transform, Transform _target);
        void StopMoveTo(Transform _transform, Transform _target);
    }
}
