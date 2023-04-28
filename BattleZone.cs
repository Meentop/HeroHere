using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZone : MonoBehaviour
{
    [SerializeField] Transform cameraPoint;

    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] CameraMove cameraMove;
    [SerializeField] GameObject door;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Player>())
        {
            foreach (var enemy in enemies)
            {
                enemy.WakeUp();
                cameraMove.SetTarget(cameraPoint);
                door.SetActive(true);
            }
        }
    }
}
