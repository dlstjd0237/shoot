using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBoos_Move : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    EliteEnemy_child_Pool eliteenemy_child_pool;
    private void Start()
    {
        eliteenemy_child_pool = FindAnyObjectByType<EliteEnemy_child_Pool>();
        StartCoroutine(Co());
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
    IEnumerator Co()
    {
        a = DOTween.Sequence();
        a.Append(transform.DOMove(new Vector2(0, 5), 11));
        yield return new WaitForSeconds(4);
        StartCoroutine(qwer());
        yield return new WaitForSeconds(3);
        StartCoroutine(qwer());
        yield return new WaitForSeconds(3);
        StartCoroutine(qwer());
        yield return new WaitForSeconds(3);
        StartCoroutine(qwer());
        yield return new WaitForSeconds(3);
        StartCoroutine(qwer());
        a.Append(transform.DOMove(new Vector2(19, 5),11));
        yield return new WaitForSeconds(15);
        a.AppendCallback(() => a.Kill());
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
