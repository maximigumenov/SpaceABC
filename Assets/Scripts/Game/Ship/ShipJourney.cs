using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipJourney : MonoBehaviour
{
    public GameObject cameraObject;
    public Transform cameraTransform;
    private List<JourneyPoint> listPoint = new List<JourneyPoint>();
    public List<JourneyTargetText> listText;
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
        GetPoints();
        ShowMoveTextUI += ShowMoveText;
        HideMoveTextUI += HideMoveText;
    }

    private void ActiveCamera() {
        ShipCamera.moveTransform = cameraTransform;
        ShipCamera.rotateTransform = transform;
        cameraObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    private void GetPoints() {
        int count = 5;
        listPoint = JourneyManager.DB.NearestList(count);
        
        GameText.Initialization(new List<string>(new string[] { "JourneyMove_ENG"}));
        for (int i = 0; i < listPoint.Count; i++)
        {
            listPoint[i].data.OnStartMove += HideMoveText;
            listPoint[i].data.ActiveName(listText[i]);
        }

        for (int i = 0; i < count; i++)
        {
            listText[i].SetText(listPoint[i].data.message.GetColor(listText[i].notSelectColor));
        }
    }

    private void HideMoveText() {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].gameObject.SetActive(false);
        }
    }

    private void ShowMoveText()
    {
        EnterTextController.RemoveAll();
        GetPoints();
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        ShowMoveTextUI -= ShowMoveText;
        HideMoveTextUI -= HideMoveText;
    }
}
