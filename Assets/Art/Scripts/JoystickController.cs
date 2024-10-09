using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private static JoystickController instance;

    private void Awake()
    {
        // Ensure only one instance of the joystick exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent the joystick from being destroyed
        }
        else
        {
            Destroy(gameObject);  // Destroy any additional joystick instances
        }
    }
}


