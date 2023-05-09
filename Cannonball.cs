using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectile
{
    protected override void Update()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            if (!Main.pause)
            {
                Movement();
                Rotation();
            }
        }
    }

    protected override void MakeDamage()
    {
        target.GetComponent<Player>().GetDamage(damage);
    }

    protected override void Movement()
    {
        transform.Translate(Vector3.forward * maxDistanceDelta);
    }

    protected override void Rotation()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            MakeDamage();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Solid")
            Destroy(gameObject);
    }
}
