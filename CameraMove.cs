using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float maxDistanceDelta;

    Transform target;

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
