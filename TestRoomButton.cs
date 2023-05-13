using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomButton : MonoBehaviour
{
    [SerializeField] TestRooms testRooms;

    [SerializeField] int number;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
            testRooms.SetTestRoom(number);
    }
}
