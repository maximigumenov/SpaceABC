using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EffectSpace.ShipEffect;

namespace EffectSpace
{
    /// <summary>
    /// Еффекты вокруг корабля
    /// </summary>
    public class ShipEffectMain
    {
        /// <summary>
        /// Шар телепортации вокруг корабля
        /// </summary>
        public StartTeleport StartTeleport = new StartTeleport();
        public FinishTeleport FinishTeleport = new FinishTeleport();
    }
}
