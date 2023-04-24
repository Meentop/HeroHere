using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChooseStation : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    public void ChooseWeapon(GameObject weapon)
    {
        foreach (var weapon1 in weapons)
        {
            weapon1.SetActive(true);
        }
        weapon.SetActive(false);
    }
}
