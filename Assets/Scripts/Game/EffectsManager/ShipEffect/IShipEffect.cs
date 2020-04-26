using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EffectSpace.ShipEffect
{
    public interface IShipEffect
    {
        void Show(Transform shipTransform, Action<int> OnStep = null);
    }
}
