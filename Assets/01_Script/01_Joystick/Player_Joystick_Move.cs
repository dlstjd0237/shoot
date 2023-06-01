using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Joystick_Move : MonoBehaviour
{
    public JoystickValue value;
    [SerializeField]float Player_Speed= 10.0f;
    private void Update()
    {
        transform.Translate(value.joyTouch/ Player_Speed );
    }
}
