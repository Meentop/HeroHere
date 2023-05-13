using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRoomButtonCanvas : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image[] images;

    [SerializeField] Color inactive, active;

    public void SetActive(bool active)
    {
        if (active)
            SetColor(this.active);
        else
            SetColor(inactive);
    }

    void SetColor(Color color)
    {
        text.color = color;
        foreach (var image in images)
        {
            image.color = color;
        }
    }
}
