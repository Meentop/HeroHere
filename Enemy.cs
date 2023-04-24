using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100;
    protected float curHp = 0;

    [SerializeField] RectTransform hpBar;

    private void Start()
    {
        curHp = maxHp;
        UpdateHpBar();
    }

    public virtual void GetDamage(float damage)
    {
        curHp -= damage;
        if (curHp < 0)
            curHp = 0;
        UpdateHpBar();
    }

    protected void UpdateHpBar()
    {
        hpBar.localScale = new Vector3(curHp / maxHp, 1, 1);
    }

}
