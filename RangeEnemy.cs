using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeEnemy : Enemy
{
    [SerializeField] Transform rotObj;
    [SerializeField] float reloadTime;
    float reloadTimer = 0;

    [SerializeField] Projectile projectile;
    [SerializeField] Transform projectileSpawnPoint;

    protected override void Update()
    {
        if (!sleep && !Main.pause)
        {
            Rotation(rotObj);
            Reload();
        }
    }

    void Reload()
    {
        if (reloadTimer < reloadTime)
            reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            Shot();
            reloadTimer = 0;
        }
    }

    protected void Shot()
    {
        GameObject projectile = Instantiate(this.projectile.gameObject, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().target = player.transform;
        projectile.transform.forward = rotObj.forward;
        print(rotObj.forward);
    }
}
