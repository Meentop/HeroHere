using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrotatedCanvas : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(60, 0, 0);
    }
}
