using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickTypeSaver : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] Dropdown dropdown;

    private void Start()
    {
        if (PlayerPrefs.HasKey("JoystickType"))
        {
            joystick.SetMode((JoystickType)PlayerPrefs.GetInt("JoystickType"));
            dropdown.value = PlayerPrefs.GetInt("JoystickType");
        }
    }

    public void Save(Dropdown dropdown)
    {
        PlayerPrefs.SetInt("JoystickType", dropdown.value);
    }
}
