using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipJourney : MonoBehaviour
{
    public GameObject cameraObject;
    public static Transform ShipTransform;
    private List<JourneyPoint> listPoint = new List<JourneyPoint>();
    public List<JourneyTargetText> listText;
    public static System.Action ShowTextUI;
    public static System.Action HideTextUI;

    // Start is called before the first frame update
    void Start()
    {
        ShipTransform = transform;
        ActiveCamera();
        GetPoints();
        ShowTextUI += ShowText;
        HideTextUI += HideText;
    }

    private void ActiveCamera() {
        cameraObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    private void GetPoints() {
        int count = 5;
        listPoint = JourneyManager.DB.NearestList(count);
        for (int i = 0; i < count; i++)
        {
            listText[i].SetText(listPoint[i].data.name);
        }

        for (int i = 0; i < listPoint.Count; i++)
        {
            listPoint[i].data.OnStartMove += HideText;
            listPoint[i].data.ActiveName();
        }
    }

    private void HideText() {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].gameObject.SetActive(false);
        }
    }

    private void ShowText()
    {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        ShowTextUI -= ShowText;
        HideTextUI -= HideText;
    }
}
