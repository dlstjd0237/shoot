using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Lv4_Move : MonoBehaviour
{
    private Animator _ani;
    private Transform _player;
    [SerializeField]
    private Enemy_Data _enemy_data;
    private bool dkdlt = false;
    private bool _dir = false;
    private void Awake()
    {
        _ani = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (dkdlt == false)
        {

            Move();
        }
        if (transform.position.y <= 4.8f) dkdlt = true;
        if(_dir == false)
        {
            leftMove();
        }
        else
        {
            right();
        }
    }

    private void Move()
    {
        transform.position += Vector3.down * _enemy_data.EnemyMoveSpeed * Time.deltaTime;      
    }
    private void leftMove()
    {
        transform.position += Vector3.left * (_enemy_data.EnemyMoveSpeed + 2) * Time.deltaTime;
        if (transform.position.x <= -9) _dir = true;
    }
    private void right()
    {
        transform.position += Vector3.right * (_enemy_data.EnemyMoveSpeed + 2) * Time.deltaTime;
        if (transform.position.x >= 9) _dir = false;
    }
}
