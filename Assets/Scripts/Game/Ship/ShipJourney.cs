
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipJourneySpace;

public class ShipJourney : MonoBehaviour
{
    public ShipJourneyText journeyText;

    public GameObject cameraObject;
    public Transform cameraTransform;
    
    
    public static Transform ShipTransform;
    public static Transform CameraTransform;
    public static System.Action ShowMoveTextUI;
    public static System.Action HideMoveTextUI;

    // Start is called before the first frame update
    void Start()
    {
        ShipTransform = transform;
        CameraTransform = cameraTransform;
        ActiveCamera();
        journeyText.GetPoints();
        ShowMoveTextUI += journeyText.ShowMoveText;
        HideMoveTextUI += journeyText.HideMoveText;
    }

    private void ActiveCamera() {
        ShipCamera.moveTransform = cameraTransform;
        ShipCamera.rotateTransform = transform;
        cameraObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    

    private void OnDestroy()
    {
        ShowMoveTextUI -= journeyText.ShowMoveText;
        HideMoveTextUI -= journeyText.HideMoveText;
    }
}
