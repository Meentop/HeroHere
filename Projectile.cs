using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Transform target;

    [SerializeField] protected float maxDistanceDelta;
    [SerializeField] protected float damage;

    protected virtual void Update()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            Movement();
            Rotation();
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                MakeDamage();
                Destroy(gameObject);
            }
        }
    }

    protected virtual void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta);
    }

    protected virtual void Rotation()
    {
        transform.rotation = Quaternion.LookRotation((transform.position - target.position).normalized);
    }

    protected abstract void MakeDamage();
}
