using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    protected override void FixedUpdate()
    {
        if(!sleep)
            MoveTowardPlayer();
    }

    protected override void Update()
    {
        if (!sleep)
            Rotation();
    }
}
