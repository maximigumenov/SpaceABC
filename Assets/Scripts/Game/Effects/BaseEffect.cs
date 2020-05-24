using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour, IEffect, IEffectPhase
{
    public Transform centre;
    public Transform cameraPosition;

    public virtual void PhaseFinish()
    {

    }

    public virtual void PhaseGame()
    {
        ShipCamera.moveTransform = cameraPosition;
        ShipCamera.rotateTransform = centre;
    }

    public virtual void PhaseStart()
    {

    }

    public virtual void Show()
    {
        Subscribe();
        JourneyPhase.PhaseStart?.Invoke();
    }

    public virtual void Subscribe()
    {

    }

    public virtual void Unsubscribe()
    {

    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
