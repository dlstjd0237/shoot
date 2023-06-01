using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Lv4_Move : MonoBehaviour
{
    private Sequence q;
    private Animator _ani;
    private Transform _player;
    
    [SerializeField] private float _moveSpeed;
    private void Awake()
    {
        _ani = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        q = DOTween.Sequence();
        q.Append(transform.DOMoveY(3, 4, false));       
    }

    private void Attack()
    {

    }
}
