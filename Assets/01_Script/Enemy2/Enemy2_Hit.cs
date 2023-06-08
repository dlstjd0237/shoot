using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum EnemyType : short
{
    Lv1 = 1,
    Lv2 = 2,
    Lv3 = 3,
    Lv4 = 4
}
public class Enemy2_Hit : MonoBehaviour
{
    [SerializeField]
    private Enemy_Data _enemyLv_data;
    [SerializeField]
    private EnemyType _enemyType;
    Enemy_Lv1_Particle_Pool _enemyLv1Pool;
    DistanceText distancetext;
    SpriteRenderer t;
    CameraManeager Cam;
    CapsuleCollider2D _capsuleCollider2D;
    int hit;
    int w = 0;
    int e = 0;
    [SerializeField] int _percent;
    Animator ani;
    [SerializeField] float _addScore;
    private void Awake()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        Cam = FindAnyObjectByType<CameraManeager>();
        distancetext = FindAnyObjectByType<DistanceText>();
        _enemyLv1Pool = FindAnyObjectByType<Enemy_Lv1_Particle_Pool>();
        ani = GetComponent<Animator>();
        t = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        _capsuleCollider2D.enabled = true;
        hit = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            ENemy2_CFXBox q = FindAnyObjectByType<ENemy2_CFXBox>();
            q.CFXarr[w].SetActive(true);
            q.CFXarr[w].transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            w++;
            if (w > q.CFXarr.Count - 1)
            {
                w = 0;
            }
            hit++;
            if (hit >= _enemyLv_data.EnemyHp)
            {
                CameraSh();


            }
            else
                Co();
        }
    }

    private void CameraSh()
    {

        _capsuleCollider2D.enabled = false;
        BoomCFX();
        switch (_enemyType)
        {
            case EnemyType.Lv1:
                ani.SetTrigger("isDie"); break;
            case EnemyType.Lv2:
                Cam.dkdlt(5, 1.4f);
                ani.SetTrigger("isDie"); break;
            case EnemyType.Lv3:
                Cam.dkdlt(7, 1.4f);
                ani.SetTrigger("isDie"); break;
            case EnemyType.Lv4:
                Cam.dkdlt(4, 1.3f);
                ani.SetTrigger("isDie"); break;
        }

    }

    Sequence dk;

    public void Die()
    {
        dk.Kill();
        Additem();
        gameObject.SetActive(false);
    }

    void BoomCFX()
    {
        switch (_enemyType)
        {
            case EnemyType.Lv1:
                _enemyLv1Pool.AddParticle(transform.position);
                distancetext.score = _addScore;
                break;
            case EnemyType.Lv2:
            case EnemyType.Lv3:
            case EnemyType.Lv4:
                Enemy2_CFX_Boom_Box EnemyBoom = FindAnyObjectByType<Enemy2_CFX_Boom_Box>();
                EnemyBoom._enemy_BoomArr[e].SetActive(true);
                EnemyBoom._enemy_BoomArr[e].transform.position = transform.position;
                e++;
                if (e > EnemyBoom._enemy_BoomArr.Count - 1)
                {
                    e = 0;
                }
                distancetext.score = _addScore;
                break;
        }

    }
    void Co()
    {

        dk = DOTween.Sequence();



        dk.Append(t.DOColor(Color.red, 0.1f));
        dk.AppendInterval(0.05f);
        dk.Append(t.DOColor(Color.white, 0.01f));
        dk.AppendInterval(0.05f);


    }
    void Additem()
    {
        if (Random.Range(0, 101) < _percent)
        {
            Item_Pool item_pool = FindAnyObjectByType<Item_Pool>();
            item_pool.AddPowerUp(transform.position);
        }

    }

}
