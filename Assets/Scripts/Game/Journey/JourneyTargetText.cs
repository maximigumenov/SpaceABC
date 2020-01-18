using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JourneyTargetText : MonoBehaviour
{
    public Text textPoint;

    public void SetText(string message) {
        textPoint.text = message;
    }
}
