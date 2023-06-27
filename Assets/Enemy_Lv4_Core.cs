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
        StartCoroutine(B());
        StartCoroutine(c());

    }
    private void Update()
    {
        x = transform.position.x;
        y = transform.position.y;

    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.0f);
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
                yield return new WaitForSeconds(0.2f);
            }
        }
        else if (Random.Range(0, 71) <= 40)
        {
            for (int i = 0; i < 3; i++)
            {
                Atk_pattern1();
                yield return new WaitForSeconds(4);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Atk_pattern1();
                yield return new WaitForSeconds(3);
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
    IEnumerator B()
    {
        float w = 0;
        while (true)
        {
            for (int i = 0; i < 30; i++)
            {
                float angle = w + (360f / 30) * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180);
                _enemy_Lv4_Bullet_pool.SpownBullet(transform.position, new Vector3(x, y, 0));
            }
            w += 1;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
    IEnumerator c()
    {
        float w = 0;
        while (true)
        {
            for (int i = 0; i < 15; i++)
            {
                float angle = w + (360f / 15) * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180);
                _enemy_Lv4_Bullet_pool.SpownBullet(transform.position, new Vector3(x, y, 0));
            }
            w += 1;
            yield return new WaitForSeconds(Random.Range(0f, 4f));
        }
    }
}
