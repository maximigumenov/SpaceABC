using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveSpace;

public class ShipCamera : MonoBehaviour
{
    private static ShipCamera Instance;
    public float speedMove = 1;
    public float speedRotate = 1;
    public static Transform moveTransform;
    public static Transform rotateTransform;
    public static float SpeedMove { get { return Instance.speedMove; } set { Instance.speedMove = value; } }
    public static float SpeedRotate { get { return Instance.speedRotate; } set { Instance.speedRotate = value; } }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
