﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAroundTarget : MonoBehaviour
{
    public Transform rotateObject;
    public Transform targetCentre;
    public Transform targetMark;
    [Space]
    public float speadMove = 1;
    public float speadRotate = 1;

    public Vector3 vectorRotate;

    private  float tempSpeadMove;
    private float tempSpeadRotate;

    private void Start()
    {
        InitializationCamera();
    }

    private void Update()
    {
        Rotate();
    }

    private void InitializationCamera() {
        ShipCamera.moveTransform = targetCentre;
        ShipCamera.rotateTransform = targetMark;

        speadMove = ShipCamera.SpeedMove;
        speadRotate = ShipCamera.SpeedRotate;
    }

    void Rotate() {
        rotateObject.Rotate(vectorRotate);
    }

    private void OnDestroy()
    {
        ShipCamera.SpeedMove = speadMove;
        ShipCamera.SpeedRotate = speadRotate;
    }
}
