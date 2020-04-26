using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip : MonoBehaviour, IEffect
{
    private int step = 0;
    public System.Action<int> OnStep;
    public float startScale = 0.01f;
    public float stepScale = 0.02f;
    public float finishScale = 1;
    public float waitTime = 1;

    public Transform target;

    public void Show()
    {
        Subscribe();
        transform.localScale = new Vector3(startScale, startScale, startScale);
        CallStep();
    }

    public void Subscribe()
    {
        
    }

    public void Unsubscribe()
    {
        
    }

    private void Update()
    {
        IncreaseSize();
        ReduceSize();
        transform.position = target.position;
    }

    private void IncreaseSize() {
        if (step == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x + stepScale, transform.localScale.y + stepScale, transform.localScale.z + stepScale);

            if (transform.localScale.x >= finishScale)
            {
                step++;
                CallStep();
                StartCoroutine(WaitScale());
            }
        }

    }

    IEnumerator WaitScale() {
        yield return new WaitForSeconds(waitTime);
        step++;
        CallStep();
    }

    private void ReduceSize()
    {
        if (step == 2)
        {
            transform.localScale = new Vector3(transform.localScale.x - stepScale, transform.localScale.y - stepScale, transform.localScale.z - stepScale);

            if (transform.localScale.x <= startScale)
            {
                step++;
                CallStep();
                Destroy(gameObject);
            }
        }
    }

    private void CallStep() {
        OnStep?.Invoke(step);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
