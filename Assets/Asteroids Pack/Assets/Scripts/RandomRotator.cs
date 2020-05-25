using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble = 0.25f;
    [Space]
    public float _randomPositionRange = 1;
    private float RandomPositionRange { get { return Random.Range(-_randomPositionRange, _randomPositionRange); } }

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    private void StartRotate() {
        transform.localRotation = Quaternion.Euler(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
    }

    [ContextMenu("SetRandomPosition")]
    public void SetRandomPosition() {
        StartRotate();
        transform.position = new Vector3(RandomPositionRange, RandomPositionRange, RandomPositionRange);
    }
}