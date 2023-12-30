using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Joystick_Move : MonoBehaviour
{
    public JoystickValue value;
    [SerializeField] float Player_Speed = 10.0f;
    private Player_Move _playerMove;
    private void Awake()
    {
        _playerMove = FindAnyObjectByType<Player_Move>();
    }
    private void Update()
    {
        if (_playerMove.die == false)
        {
            Debug.Log(value);
            transform.Translate(value.joyTouch / Player_Speed);
        }
    }
}
