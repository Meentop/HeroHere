using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    bool isSleep = true, enemyInRange = false;

    [SerializeField] float followSpeed, radius;

    Transform pivot, player;

    [SerializeField] Transform attackPoint;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isSleep)
        {
            transform.position = Vector3.Lerp(transform.position, pivot.position, followSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, pivot.rotation, followSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.position, followSpeed);
            if(curTarget != null)
                SetRotation(curTarget);
        }
    }

    public void SetWeaponPivot(Transform pivot)
    {
        this.pivot = pivot;
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    public float GetRadius()
    {
        return radius;
    }

    public void EnemyEnteredInRange()
    {
        anim.SetBool("EnemyInRange", true);
        isSleep = false;
        enemyInRange = true;
    }

    public void EnemyIsOutRange()
    {
        enemyInRange = false;
    }

    protected Transform curTarget = null, nextTarget = null;

    public void SetRotation(Transform target)
    {
        Vector3 targetPos = new Vector3(target.position.x, 0, target.position.z);
        Vector3 weaponPos = new Vector3(attackPoint.position.x, 0, attackPoint.position.z);
        Quaternion rotation = Quaternion.LookRotation((targetPos - weaponPos).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, followSpeed);
    }

    public void SetCurTarget()
    {
        curTarget = nextTarget;
    }

    public void SetNextTarget(Transform target)
    {
        nextTarget = target;
    }

    public void CheckEnemyInRange()
    {
        if (!enemyInRange)
        {
            anim.SetBool("EnemyInRange", false);
            isSleep = true;
        }
    }
}
