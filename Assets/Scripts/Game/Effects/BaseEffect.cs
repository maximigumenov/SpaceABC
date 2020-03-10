using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour, IEffect
{
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
