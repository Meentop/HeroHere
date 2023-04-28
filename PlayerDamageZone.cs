using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageZone : DamageZone
{
    List<Enemy> damagedEnemies = new List<Enemy>();

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (!WasDamaged(enemy))
            {
                enemy.GetDamage(damage);
                damagedEnemies.Add(enemy);
            }
        }
    }

    bool WasDamaged(Enemy enemy)
    {
        foreach (var enemy1 in damagedEnemies)
        {
            if (enemy == enemy1)
                return true;
        }
        return false;
    }

    public void ClearDamagedEnemies()
    {
        damagedEnemies.Clear();
    }
}
