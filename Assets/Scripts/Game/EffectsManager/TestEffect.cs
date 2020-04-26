using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffect : MonoBehaviour
{

    public Transform ship;

    // Start is called before the first frame update
    void Start()
    {
        Show();
    }

    public void Show() {
        Effect.ShipEffect.StartTeleport.Show(ship);
        StartCoroutine(WaitHide());
    }

    public void Hide()
    {
        Effect.ShipEffect.FinishTeleport.Show(ship);
    }

    IEnumerator WaitHide() {
        yield return new WaitForSeconds(10);
        Hide();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
