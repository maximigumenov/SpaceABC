﻿using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrillEffect : BaseEffect, IEffect, IEffectPhase
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
        JourneyPhase.EffectFinish?.Invoke();
    }

    public override void PhaseGame()
    {
        StartCoroutine(WaitGame());
        ShipCamera.moveTransform = cameraPosition;
        ShipCamera.rotateTransform = centre;
    }

    public override void PhaseStart()
    {
        for (int i = 0; i < listShowObjects.Count; i++)
        {
            listShowObjects[i].SetActive(true);
        }

        for (int i = 0; i < listHideObjects.Count; i++)
        {
            listHideObjects[i].SetActive(false);
        }

        GameText.Initialization(new List<string>(new string[] { nameObjectMove }));
        StartCoroutine(WaitCreateTarget(0, 5));

        JourneyPhase.PhaseGame?.Invoke();
    }


    IEnumerator WaitGame() {
        yield return new WaitForSeconds(timeGame);
        
    }

    IEnumerator WaitCreateTarget(int step, int maxStep)
    {
        yield return new WaitForSeconds(1);
        if (step < maxStep)
        {
            CreateTarget(step + 1, maxStep);
        }
        else
        {
            JourneyPhase.PhaseFinish?.Invoke();
        }
        
    }
    

    private void CreateTarget(int step, int maxStep)
    {
        Action CallWithStop = () => { StartCoroutine(WaitCreateTarget(step, maxStep)); };
        Base_OnGood base_OnGood = new Base_OnGood(nameGoodPrefab);
        Base_OnBad base_OnBad = new Base_OnBad(nameBadPrefab);
        Base_OnStop base_OnStop = new Base_OnStop(CallWithStop);
        
        CreateTarget(namePrefab, nameObjectMove, transformGenerate, targetsToMove, base_OnGood, base_OnBad, base_OnStop);
    }
}
