using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDoll : Enemy
{
    [SerializeField] float maxHealthTime = 3, healthTimer = 3;

    protected override void Start()
    {
        base.Start();
        sleep = false;
    }

    protected override void FixedUpdate()
    {
        if(curHp < maxHp && healthTimer >= 0)
        {
            healthTimer -= Time.fixedDeltaTime;
        }
        if(healthTimer <= 0 && curHp < maxHp)
        {
            curHp += 0.5f;
            if (curHp >= maxHp)
            {
                curHp = maxHp;
                healthTimer = maxHealthTime;
            }
            UpdateHpBar();
        }
    }

    public override void GetDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
            curHp = 0;
        UpdateHpBar();
        healthTimer = maxHealthTime;
    }
}
