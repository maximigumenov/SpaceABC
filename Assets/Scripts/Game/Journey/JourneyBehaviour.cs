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
    }

    private void CreateJourney() {
        JourneyManager.generate.Create(mainTransform);
    }
}
