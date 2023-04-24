using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] WeaponChooseStation weaponChooseStation;

    [SerializeField] GameObject weaponPrefab;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Player>())
        {
            print(gameObject.name);
            weaponChooseStation.ChooseWeapon(gameObject);
            collider.gameObject.GetComponent<Player>().SetWeapon(weaponPrefab);
        }
    }
}
