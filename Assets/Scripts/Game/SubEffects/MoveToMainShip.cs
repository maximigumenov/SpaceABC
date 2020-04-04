using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMainShip : MoveSubEffect
{
    private void Start()
    {

        moveObject.OnStop = () => {
            DestroyObject();
        };
        MoveTo(transform, ShipJourney.ShipTransform);
    }

    void DestroyObject() {

        Destroy(gameObject);
    }
}
