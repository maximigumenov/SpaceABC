using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakeEffect : BaseEffect, IEffect, IEffectPhase
{
    [Header("Text library")]
    public string nameObjectMove = "TransitionMetal_ENG";
    [Header("Prefab names")]
    public string namePrefab = "DrillObject";
    public string nameGoodPrefab = "DrillObjectGood";
    public string nameBadPrefab = "DrillObjectBad";
    [Space]
    public float timeGame = 5;
    public List<GameObject> listShowObjects;
    public List<GameObject> listHideObjects;
    [Space]
    public Transform transformGenerate;

    public List<Transform> targetsToMove;

    public override void PhaseFinish()
    {
        base.PhaseFinish();
    }

    public override void PhaseGame()
    {
        base.PhaseGame();
    }

    public override void PhaseStart()
    {
        base.PhaseStart();
    }

    private void CreateTarget(int step, int maxStep)
    {
        Action CallWithStop = () => {  };
        Base_OnGood base_OnGood = new Base_OnGood(nameGoodPrefab);
        Base_OnBad base_OnBad = new Base_OnBad(nameBadPrefab);
        Base_OnStop base_OnStop = new Base_OnStop(CallWithStop);

        CreateTarget(namePrefab, nameObjectMove, transformGenerate, targetsToMove, base_OnGood, base_OnBad, base_OnStop);
    }
}
