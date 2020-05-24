using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashJourney : BaseJourney, IJourneyObject, IJourneyObjectData
{
    public List<Transform> crashElements;
    public float distance = 10;

    private float RandomDistance { get { return Random.Range(-distance, distance); } }

    public override void Start()
    {
        base.Start();
        SetPositionElements();
    }

    private void SetPositionElements() {
        for (int i = 0; i < crashElements.Count; i++)
        {
            crashElements[i].localPosition = new Vector3(RandomDistance, RandomDistance, RandomDistance);
        }
    }

    public override void Sort(out List<string> notActiveType)
    {
        base.Sort(out notActiveType);

        notActiveType.Add("JourneyMove_ENG");
        notActiveType.Add("JourneyExploration_ENG");
    }
}
