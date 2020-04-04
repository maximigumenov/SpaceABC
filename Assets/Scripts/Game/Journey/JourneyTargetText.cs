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

    private void Start()
    {
        
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForFixedUpdate();
        textPoint.text = textPoint.text + " ";
        textPoint.text = textPoint.text.Substring(0, textPoint.text.Length - 1);
    }
}
