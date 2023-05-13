using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageZone : DamageZone
{
    protected override void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.GetDamage(damage);
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.GetDamage(damage);
        }
    }
}
