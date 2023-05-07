using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : RangeEnemy
{
    public override void GetDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            battleZone.RemoveEnemy(this);
            Destroy(gameObject);
        }
        UpdateHpBar();
    }

    protected override void Rotation(Transform rotObj)
    {
        Vector3 direction = (player.transform.position - rotObj.position).normalized;
        Quaternion endRotation = Quaternion.LookRotation(direction);
        Quaternion rot = Quaternion.RotateTowards(rotObj.rotation, endRotation, rotationSpeed);
        rotObj.rotation = Quaternion.Euler(new Vector3(rotObj.rotation.eulerAngles.x, rot.eulerAngles.y, rotObj.rotation.eulerAngles.z));
    }
}
