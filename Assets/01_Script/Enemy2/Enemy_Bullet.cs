using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Bullet : MonoBehaviour
{

    [SerializeField] float speed;
    Transform player;
    Sequence q;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        //q = DOTween.Sequence();
        //q.Append(transform.DOMove(player.position, 3).SetEase(Ease.InQuart));
        //q.AppendCallback(() => q.Kill());
    }
    private void OnEnable()
    {
        if (Random.Range(0, 101) <= 70)
        {

            q = DOTween.Sequence();
            q.Append(transform.DOMove(player.position, 3).SetEase(Ease.InQuart));
        }

    }
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -6)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            CameraManeager Cam = FindAnyObjectByType<CameraManeager>();
            Cam.dkdlt(3, 0.2f);
            collision.gameObject.SetActive(false);
            ParticleEnemy_Bullet Parti = FindAnyObjectByType<ParticleEnemy_Bullet>();
            Parti.particle_EnemyBulletList[Parti.w].SetActive(true);
            Parti.particle_EnemyBulletList[Parti.w].transform.position = transform.position;
            Parti.w++;
            if (Parti.w > Parti.particle_EnemyBulletList.Count - 1) Parti.w = 0;
            gameObject.SetActive(false);
        }
    }
}
