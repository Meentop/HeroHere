using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWeaponRadius : MonoBehaviour
{
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawCircle(int steps, float radius)
    {
        lineRenderer.positionCount = steps + 1;

        for (int i = 0; i < steps + 1; i++)
        {
            float circumferenceProgress = (float)i / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, 0, y);

            lineRenderer.SetPosition(i, currentPosition);
        }
    }
}
