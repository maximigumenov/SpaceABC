using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatheringEffect : BaseEffect, IEffect, IEffectPhase
{
    public override void Subscribe()
    {
        base.Subscribe();
        JourneyPhase.PhaseStart += PhaseStart;
        JourneyPhase.PhaseGame += PhaseGame;
        JourneyPhase.PhaseFinish += PhaseFinish;
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        JourneyPhase.PhaseStart -= PhaseStart;
        JourneyPhase.PhaseGame -= PhaseGame;
        JourneyPhase.PhaseFinish -= PhaseFinish;
    }


    public override void PhaseFinish()
    {
        base.PhaseFinish();
        Debug.Log("PhaseFinish");
    }

    public override void PhaseGame()
    {
        base.PhaseGame();
        Debug.Log("PhaseGame");
    }

    public override void PhaseStart()
    {
        base.PhaseStart();
        GameText.Initialization(new List<string>(new string[] { "TransitionMetal_ENG" }));
       

        JourneyPhase.PhaseGame?.Invoke();
        Debug.Log("PhaseStart");
    }
}
