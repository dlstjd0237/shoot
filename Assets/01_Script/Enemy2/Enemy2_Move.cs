using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy2_Move : Enemy
{
    Transform player;
    new AudioSource audio;
    int q = 0;
    Sequence seq;
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
        seq.Kill();

    }
    void Co()
    {
        if(seq !=null&&seq.IsActive()) seq.Kill();
        seq = DOTween.Sequence();

        seq.Append(audio.DOFade(0,1));
        seq.Join(transform.DOMoveX(player.position.x, 1f));
        //audio.Play();
        seq.Append(audio.DOFade(0, 1));

        seq.Join(transform.DOMoveY(transform.position.y - 3, 1));
        //audio.Play();
        StartCoroutine("En");
        seq.Append(audio.DOFade(0, 1));

        seq.Join(transform.DOMoveY(transform.position.y, 1));
        //audio.Play();
        
        seq.AppendCallback(() => { Co(); });


    }
    private void FixedUpdate()
    {
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
        if (q > enemyBullet.enemyBulletArr.Count - 1) q = 0;
        for (int i = 0; i < 9; i++)
        {
            enemyBullet.enemyBulletArr[q].SetActive(true);
            enemyBullet.enemyBulletArr[q].transform.position = new Vector2(transform.position.x + Random.Range(-0.5f, 0.6f), transform.position.y);
            q += 1;
            yield return new WaitForSeconds(0.05f);

        }
        yield return null;
    }

}