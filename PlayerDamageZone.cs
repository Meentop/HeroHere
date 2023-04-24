using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageZone : DamageZone
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }
}
