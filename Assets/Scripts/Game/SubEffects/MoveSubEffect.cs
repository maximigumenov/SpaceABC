using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EnterTextSpace;
using GameTextSpace;
using Strategic;

public class MoveSubEffect : MonoBehaviour, ISetText, IMoveObject
{
    [SerializeField] BaseSetText _baseSetText;
    public BaseSetText baseSetText { get { return _baseSetText; } set { _baseSetText = value; } }

    [SerializeField] BaseMoveObject _moveObject;
    public BaseMoveObject moveObject { get { return _moveObject; } set { _moveObject = value; } }


    [SerializeField] float _speedMove = 1;
    public float speedMove { get { return _speedMove; } set { _speedMove = value; } }

    [SerializeField] float _speedRotate = 1;
    public float speedRotate { get { return _speedRotate; } set { _speedRotate = value; } }

    [SerializeField] float _minDistance = 0.1f;
    public float minDistance { get { return _minDistance; } set { _minDistance = value; } }

    
    public void MoveTo(Transform _transform, Transform _target)
    {
        _moveObject.MoveToTarget(_transform, _target, speedMove, speedRotate, minDistance);
    }

    public void StopMoveTo(Transform _transform, Transform _target)
    {
        _moveObject.StopMoveToTarget(_transform, _target);
    }
}
