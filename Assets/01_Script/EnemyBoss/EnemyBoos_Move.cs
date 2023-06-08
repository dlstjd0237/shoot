using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBoos_Move : MonoBehaviour
{
    EliteEnemy_child_Pool eliteenemy_child_pool;
    private void Start()
    {
        eliteenemy_child_pool = FindAnyObjectByType<EliteEnemy_child_Pool>();
        Co();
    }
    private void Update()
    {
        if (transform.position.x >= 16)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if (a != null && a.IsActive()) a.Kill();
    }

    Sequence a ;

    private void Co()
    {
        a = DOTween.Sequence().SetAutoKill(false);

        a.Append(transform.DOMove(new Vector2(-4, 6), 5,false));
        a.AppendInterval(2);
        a.AppendCallback(() => asdf());
        a.AppendInterval(3);
        a.Append(transform.DOMove(new Vector2(0, 6), 5, false));
        a.AppendCallback(() => asdf());
        a.AppendInterval(3);
        a.AppendCallback(() => asdf());
        a.AppendInterval(3);
        a.AppendCallback(() => asdf());
        a.AppendInterval(3);
        a.AppendCallback(() => asdf());
        a.Append(transform.DOMove(new Vector2(19, 5),11));
        a.AppendInterval(15);
        a.AppendCallback(() => a.Kill());
    }
    void asdf()
    {
        if(gameObject.activeSelf)
        StartCoroutine(qwer());
    }
    IEnumerator qwer()
    {
        for (int i = 0; i < 5; i++)
        {
            eliteenemy_child_pool.AddChild(new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 3), transform.position.y));
            eliteenemy_child_pool.AddChild(new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 3), transform.position.y));
            eliteenemy_child_pool.AddBullet(new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 3), transform.position.y));
            eliteenemy_child_pool.AddBullet(new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 3), transform.position.y));

            yield return new WaitForSeconds(0.1f);
        }
    }
   

}
