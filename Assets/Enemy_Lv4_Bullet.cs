using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv4_Bullet : MonoBehaviour
{
    private Vector3 _movedir = Vector3.zero;
    [SerializeField]
    private Enemy_Data _enemy_Data;
    Animator Ani;
    private void Awake()
    {
        Ani = GetComponent<Animator>();
    }
    private void Update()
    {
        ToMove(_movedir);
        transform.position += _movedir * _enemy_Data.EnemyBulletSpeed * Time.deltaTime;
        Die();
    }
    private void OnDisable()
    {
        _movedir = Vector3.zero;
    }
    public void ToMove(Vector3 dir)
    {
        _movedir = dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Ani.SetTrigger("Die");
        }
    }
    public void Qwer()
    {
        gameObject.SetActive(false);
    }
    void Die()
    {
        if(transform.position.y < -7)
        {
            gameObject.SetActive(false);
        }
    }
}
