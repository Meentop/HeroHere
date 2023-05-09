using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZone : MonoBehaviour
{
    [SerializeField] Transform cameraPoint;

    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] CameraMove cameraMove;
    [SerializeField] GameObject inDoor, outDoor;

    bool active = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Player>() && !active)
        {
            foreach (var enemy in enemies)
            {
                enemy.WakeUp();
                cameraMove.SetTarget(cameraPoint);
                inDoor.SetActive(true);
                active = true;
            }
            Main.Instance.curBattleZone = this;
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        CheckRoomClear();
    }

    void CheckRoomClear()
    {
        if (enemies.Count == 0)
            outDoor.SetActive(false);
    }

    public void StopAllEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.StopMovement();
        }
    }
}
