using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTextSpace;
using System;
using EnterTextSpace;
using MoveSpace;

public class AsteroidJourney : BaseJourney, IJourneyObject, IJourneyObjectData
{
    public override void Start()
    {
        base.Start();
    }

    public override void Sort(out List<string> notActiveType)
    {
        base.Sort(out notActiveType);
    }
}
