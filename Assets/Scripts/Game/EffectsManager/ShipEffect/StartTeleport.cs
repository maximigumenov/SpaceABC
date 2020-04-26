using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectSpace.ShipEffect
{
    public class StartTeleport : IShipEffect
    {
        Transform shipTransform;

        public void Show(Transform shipTransform, Action<int> OnStep = null)
        {
            this.shipTransform = shipTransform;
            shipTransform.gameObject.SetActive(false);
            GameObject teleportPrefab = Load.Prefab.Get("Teleport");
            GameObject teleportObj = MonoBehaviour.Instantiate(teleportPrefab);
            TeleportShip teleportShip = teleportObj.GetComponent<TeleportShip>();
            teleportShip.transform.position = shipTransform.position;
            teleportShip.target = shipTransform;
            teleportShip.OnStep += StepTeleport;
            teleportShip.OnStep += OnStep;
            teleportShip.Show();
        }

        void StepTeleport(int step)
        {
            if (step == 2)
            {
                shipTransform.gameObject.SetActive(true);
            }
        }
    }
}
