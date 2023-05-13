using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRooms : MonoBehaviour
{
    [SerializeField] TestRoomButtonCanvas[] canvases;

    [SerializeField] GameObject[] rooms;

    private void Start()
    {
        SetTestRoom(0);
    }

    public void SetTestRoom(int number)
    {
        foreach (var canvas in canvases)
        {
            canvas.SetActive(false);
        }
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        canvases[number].SetActive(true);
        Instantiate(rooms[number], transform);
    }
}
