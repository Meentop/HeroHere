using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;

    [SerializeField] float maxDistanceDelta;

    private void Update()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta);
            transform.rotation = Quaternion.LookRotation((transform.position - target.position).normalized);
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
                Destroy(gameObject);
        }
    }
}
