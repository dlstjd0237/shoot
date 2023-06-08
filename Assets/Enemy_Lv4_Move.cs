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
        if (transform.position.y <= 4.5f) dkdlt = true;
    }

    private void Move()
    {
        transform.position += Vector3.down * _enemy_data.EnemyMoveSpeed * Time.deltaTime;
    }
}
