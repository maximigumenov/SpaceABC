using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectPhase
{
    void PhaseStart();
    void PhaseGame();
    void PhaseFinish();
}
