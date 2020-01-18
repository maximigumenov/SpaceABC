using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyBehaviour : MonoBehaviour
{
    public Transform mainTransform;

    // Start is called before the first frame update
    void Start()
    {
        CreateJourney();
        CreateShip();
    }

    private void CreateJourney() {
        JourneyManager.generate.Create(mainTransform);
    }

    private void CreateShip()
    {
        GameObject shipPrefab = Load.Prefab.Get("Ship");
        Instantiate(shipPrefab);
    }
}
