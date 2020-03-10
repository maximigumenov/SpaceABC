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

        JourneyPhase.PhaseGame?.Invoke();
    }


    IEnumerator WaitGame() {
        yield return new WaitForSeconds(timeGame);
        JourneyPhase.PhaseFinish?.Invoke();
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
