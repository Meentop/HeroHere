using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
    protected override void MakeDamage()
    {
        target.GetComponent<Enemy>().GetDamage(damage);
    }
}
