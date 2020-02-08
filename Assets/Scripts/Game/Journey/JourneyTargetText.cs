using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JourneyTargetText : MonoBehaviour
{
    public Text textPoint;

    public string selectColor = "FF0000";
    public string notSelectColor = "1400FF";

    public void SetText(string message) {
        textPoint.text = message;
    }

    
}
