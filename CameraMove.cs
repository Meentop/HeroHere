using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static CameraMove Instance;

    [SerializeField] float maxDistanceDelta;

    Transform target;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
