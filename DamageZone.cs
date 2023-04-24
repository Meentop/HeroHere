using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageZone : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }
}
