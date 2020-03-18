﻿using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillEffect : BaseEffect, IEffect, IEffectPhase
{
    public float timeGame = 5;
    public List<GameObject> listShowObjects;
    public List<GameObject> listHideObjects;
    public Transform centre;
    public Transform cameraPosition;
    [Space]
    public Transform transformGenerate;

    public List<Transform> targetsToMove;

    public void PhaseFinish()
    {
        JourneyPhase.EffectFinish?.Invoke();
    }

    public void PhaseGame()
    {
        StartCoroutine(WaitGame());
        ShipCamera.moveTransform = cameraPosition;
        ShipCamera.rotateTransform = centre;
    }

    public void PhaseStart()
    {
        for (int i = 0; i < listShowObjects.Count; i++)
        {
            listShowObjects[i].SetActive(true);
        }

        for (int i = 0; i < listHideObjects.Count; i++)
        {
            listHideObjects[i].SetActive(false);
        }

       
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

    private void CreateTarget(int step, int maxStep) {
       GameObject targetObject = Instantiate(Load.Prefab.Get("DrillObject"), transformGenerate);
        MoveSubEffect moveSubEffect = targetObject.GetComponent<MoveSubEffect>();
        Transform targetMove = targetsToMove.Random();

        moveSubEffect.baseSetText.Show("JourneyWork_ENG");
        moveSubEffect.baseSetText.OnGood = (str, textObj) =>
        {
            moveSubEffect.StopMoveTo(targetObject.transform, targetMove);
            //Destroy(targetObject);
            //EnterTextController.RemoveAll();
            
        };

        moveSubEffect.baseSetText.OnBed = (str, textObj) =>
        {
            moveSubEffect.StopMoveTo(targetObject.transform, targetMove);
        };

        moveSubEffect.moveObject.OnStop = () => {
            Debug.LogError("Stop");
            Destroy(targetObject);
            EnterTextController.RemoveAll();
            StartCoroutine(WaitCreateTarget(step, maxStep));
        };

       
        moveSubEffect.MoveTo(targetObject.transform, targetMove);
    }

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
    
}