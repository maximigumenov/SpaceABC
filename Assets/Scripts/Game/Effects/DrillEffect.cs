using EnterTextSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void CreateTarget(int step, int maxStep) {
       GameObject targetObject = Instantiate(Load.Prefab.Get(namePrefab), transformGenerate);
        MoveSubEffect moveSubEffect = targetObject.GetComponent<MoveSubEffect>();
        Transform targetMove = targetsToMove.Random();
        EnterTextController.RemoveAll();
        moveSubEffect.baseSetText.Show(nameObjectMove);
        moveSubEffect.baseSetText.OnGood = (str, textObj) =>
        {
            GameObject targetObjectGood = Instantiate(Load.Prefab.Get(nameGoodPrefab), transformGenerate);
            targetObjectGood.transform.SetParent(null);
            targetObjectGood.transform.position = moveSubEffect.transform.position;
            moveSubEffect.StopMoveTo(targetObject.transform, targetMove);
            

        };

        moveSubEffect.baseSetText.OnBed = (str, textObj) =>
        {
            GameObject targetObjectBad = Instantiate(Load.Prefab.Get(nameBadPrefab), transformGenerate);
            targetObjectBad.transform.SetParent(null);
            targetObjectBad.transform.position = moveSubEffect.transform.position;
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
