using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveSpace;

public class ShipCamera : MonoBehaviour
{
    public float speedMove = 1;
    public float speedRotate = 1;
    public static Transform moveTransform;
    public static Transform rotateTransform;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        MoveManager.work.MoveTo(transform, moveTransform, speedMove);
        MoveManager.work.RotateTo(transform, rotateTransform, speedRotate);
    }
}
