using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy2_Move : Enemy
{
    Transform player;
    new AudioSource audio;
    Sequence seq;
    Vector2 qwer;
    private void Awake()
    {

        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        Co();
    }
    private void OnDisable()
    {
        if (seq != null && seq.IsActive()) seq.Kill();

    }
    void Co()
    {
        if(seq !=null&&seq.IsActive()) seq.Kill();
        seq = DOTween.Sequence().SetAutoKill(false);

        seq.Append(audio.DOFade(0,1));
        seq.Join(transform.DOMoveX(player.position.x, 1f));
        //audio.Play();
        seq.Append(audio.DOFade(0, 1));

        seq.Join(transform.DOMoveY(transform.position.y - 1, 1));
        //audio.Play();
        StartCoroutine("En");
        seq.Append(audio.DOFade(0, 1));

        seq.Join(transform.DOMoveY(transform.position.y, 1));
        //audio.Play();
        
        seq.AppendCallback(() => { Co(); });


    }
    private void FixedUpdate()
    {
        qwer = transform.position;
        transform.position += Vector3.down * 0.5f * Time.deltaTime;
        if (transform.position.y < -7)
        {
            gameObject.SetActive(false);
        }
    }
     IEnumerator En()
    {
        yield return new WaitForSeconds(1.3f);
        EnemyBulletBox enemyBullet = FindAnyObjectByType<EnemyBulletBox>();
        for (int i = 0; i < 9; i++)
        {
            enemyBullet.AddBullet(qwer);
            yield return new WaitForSeconds(0.05f);

        }
        yield return null;
    }

}
