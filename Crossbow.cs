using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
    [SerializeField] Arrow arrow;
    [SerializeField] Transform arrowSpawnPoint;

    public void ShotArrow()
    {
        Instantiate(arrow.gameObject, arrowSpawnPoint.position, Quaternion.identity).GetComponent<Arrow>().target = curTarget;
    }
}
