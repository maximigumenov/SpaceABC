using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MoveSpace;

public class BaseEffect : MonoBehaviour, IEffect, IEffectPhase
{
    public Transform centre;
    public Transform cameraPosition;
    public Transform shipPosition;

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
        SetShipPosition();
    }

    public virtual void Show()
    {
        Subscribe();
        JourneyPhase.PhaseStart?.Invoke();
    }

    public virtual void Subscribe()
    {
        JourneyPhase.PhaseStart += PhaseStart;
        JourneyPhase.PhaseGame += PhaseGame;
        JourneyPhase.PhaseFinish += PhaseFinish;
    }

    public virtual void Unsubscribe()
    {
        JourneyPhase.PhaseStart -= PhaseStart;
        JourneyPhase.PhaseGame -= PhaseGame;
        JourneyPhase.PhaseFinish -= PhaseFinish;
    }

    protected void SetShipPosition() {
        if (shipPosition != null)
        {
            MoveManager.Add(ShipJourney.ShipTransform, shipPosition, 10, 10, 0.1f);
        }
    }

    protected void CreateTarget(
        string namePrefab,
        string nameObjectMove,
        Transform transformGenerate,
        List<Transform> targetsToMove,
        Base_OnGood _OnGood,
        Base_OnBad _OnBad,
        Base_OnStop _OnStop
        )
    {
        GameObject targetObject = Instantiate(Load.Prefab.Get(namePrefab), transformGenerate);
        MoveSubEffect moveSubEffect = targetObject.GetComponent<MoveSubEffect>();
        Transform targetMove = targetsToMove.Random();
        EnterTextController.RemoveAll();
        moveSubEffect.baseSetText.Show(nameObjectMove);
        moveSubEffect.baseSetText.OnGood = (str, textObj) =>
        {
            _OnGood.Initialization(transformGenerate, moveSubEffect, targetObject, targetMove);
            _OnGood?.Call();
        };

        moveSubEffect.baseSetText.OnBed = (str, textObj) =>
        {
            _OnBad.Initialization(transformGenerate, moveSubEffect, targetObject, targetMove);
            _OnBad?.Call();
        };

        moveSubEffect.moveObject.OnStop = () =>
        {
            _OnStop.Initialization(targetObject);
            _OnStop?.Call();
        };


        moveSubEffect.MoveTo(targetObject.transform, targetMove);
    }

    

   

    public class Base_OnGood {
        public string nameGoodPrefab;
        public Transform transformGenerate;
        public MoveSubEffect moveSubEffect;
        public GameObject targetObject;
        public Transform targetMove;

        public Base_OnGood(string nameGoodPrefab) {
            this.nameGoodPrefab = nameGoodPrefab;
        }

        public void Initialization(
            Transform transformGenerate,
            MoveSubEffect moveSubEffect,
            GameObject targetObject,
            Transform targetMove
            )
        {
            this.transformGenerate = transformGenerate;
            this.moveSubEffect = moveSubEffect;
            this.targetObject = targetObject;
            this.targetMove = targetMove;
        }

        public void Call()
        {
            GameObject targetObjectGood = Instantiate(Load.Prefab.Get(nameGoodPrefab), transformGenerate);
            targetObjectGood.transform.SetParent(null);
            targetObjectGood.transform.position = moveSubEffect.transform.position;
            moveSubEffect.StopMoveTo(targetObject.transform, targetMove);
        }
    }

    public class Base_OnBad
    {
        public string nameBadPrefab;
        public Transform transformGenerate;
        public MoveSubEffect moveSubEffect;
        public GameObject targetObject;
        public Transform targetMove;

        public Base_OnBad(string nameBadPrefab)
        {
            this.nameBadPrefab = nameBadPrefab;
        }

        public void Initialization(
            Transform transformGenerate,
            MoveSubEffect moveSubEffect,
            GameObject targetObject,
            Transform targetMove
            ) {
            this.transformGenerate = transformGenerate;
            this.moveSubEffect = moveSubEffect;
            this.targetObject = targetObject;
            this.targetMove = targetMove;
        }

        public void Call()
        {
            GameObject targetObjectBad = Instantiate(Load.Prefab.Get(nameBadPrefab), transformGenerate);
            targetObjectBad.transform.SetParent(null);
            targetObjectBad.transform.position = moveSubEffect.transform.position;
            moveSubEffect.StopMoveTo(targetObject.transform, targetMove);
        }
    }

    public class Base_OnStop
    {
        public GameObject targetObject;
        public Action OnCall;

        public Base_OnStop(Action OnCall)
        {
            this.OnCall = OnCall;
        }

        public void Initialization(
            GameObject targetObject
            )
        {
            this.targetObject = targetObject;
        }

        public void Call()
        {
            Debug.LogError("Stop");
            Destroy(targetObject);
            EnterTextController.RemoveAll();
            OnCall?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
