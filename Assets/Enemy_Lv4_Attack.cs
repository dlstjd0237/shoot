using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv4_Attack : MonoBehaviour
{
    private Enemy_Lv4_Bullet_Pool _enemy_bullet;
    private void Awake()
    {
        _enemy_bullet = FindAnyObjectByType<Enemy_Lv4_Bullet_Pool>();

    }
    private void Start()
    {
        StartCoroutine(Co());
    }
    IEnumerator Co()
    {
        for (int i = 0; i < 2; i++)
        {

            a(transform.position, new Vector3(0, -1, 0));
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(Co());
    }
    void a(Vector3 dir1, Vector3 dir2)
    {
        _enemy_bullet.SpownBullet(dir1, dir2);
    }

   
}
