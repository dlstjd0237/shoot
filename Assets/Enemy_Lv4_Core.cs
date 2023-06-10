using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv4_Core : MonoBehaviour
{
    private Enemy_Lv4_Bullet_Pool _enemy_Lv4_Bullet_pool;
    float x;
    float y;
    private void Awake()
    {
        _enemy_Lv4_Bullet_pool = FindAnyObjectByType<Enemy_Lv4_Bullet_Pool>();
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        x = transform.position.x;
        y = transform.position.y;

    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Atk_Start());
        StartCoroutine(Attack());
    }
    IEnumerator Atk_Start()
    {
        if (Random.Range(0, 101) <= 30)
        {
            for (int i = 0; i < 3; i++)
            {
                Atk_pattern1();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (Random.Range(0, 71) <= 40)
        {
            for (int i = 0; i < 3; i++)
            {
                Atk_pattern1();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Atk_pattern1();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void Atk_pattern1()
    {
        for (int i = 0; i < 5; i++)
        {
            _enemy_Lv4_Bullet_pool.SpownBullet(new Vector2(x + 1, y), new Vector3((float)i / 10, -1, 0));
        }
        for (int i = 0; i < 5; i++)
        {
            _enemy_Lv4_Bullet_pool.SpownBullet(new Vector2(x - 1, y), new Vector3(-(float)i / 10, -1, 0));
        }
    }
}
