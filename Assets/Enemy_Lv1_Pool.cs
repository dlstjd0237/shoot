using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv1_Pool : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyL1;
    List<GameObject> _enemyList = new List<GameObject>();
    EnemyBoos_Box Boss;
    Enemy2_Box En2Box;
    [SerializeField] float crruntTime = 2;
    public int Count = 0;
    bool _bossTime = false;

    private void Awake()
    {
        crruntTime = 2;
        En2Box = FindAnyObjectByType<Enemy2_Box>();
        Boss = FindAnyObjectByType<EnemyBoos_Box>();
        for (int i = 0; i < 200; i++)
        {
            GameObject qwer = Instantiate(_enemyL1[Random.Range(0, _enemyL1.Length)], transform);
            _enemyList.Add(qwer);
            qwer.SetActive(false);
        }
    }

    public void Spawn()
    {
        Spawn1();
    }
    void Spawn1()
    {
        StartCoroutine(linearSpawn());


    }
    IEnumerator linearSpawn()
    {
        while (true)
        {
            rlahEl(new Vector2(-10, 6));
            rlahEl(new Vector2(10, 6));
            rlahEl(new Vector2(-8, 6));
            rlahEl(new Vector2(8, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-6, 6));
            rlahEl(new Vector2(6, 6));
            yield return new WaitForSeconds(crruntTime);//6ÃÊ
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(0, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            AddEliteEnemy();
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-6, 6));
            rlahEl(new Vector2(6, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            rlahEl(new Vector2(-10, 6));
            rlahEl(new Vector2(10, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            AddBoss();
            rlahEl(new Vector2(-10, 6));
            rlahEl(new Vector2(10, 6));
            rlahEl(new Vector2(-8, 6));
            rlahEl(new Vector2(8, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-6, 6));
            rlahEl(new Vector2(6, 6));
            yield return new WaitForSeconds(crruntTime);//6ÃÊ
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(0, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            AddEliteEnemy();
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-6, 6));
            rlahEl(new Vector2(6, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            rlahEl(new Vector2(-10, 6));
            rlahEl(new Vector2(10, 6));
            yield return new WaitForSeconds(crruntTime);
            rlahEl(new Vector2(-4, 6));
            rlahEl(new Vector2(4, 6));
            rlahEl(new Vector2(-2, 6));
            rlahEl(new Vector2(2, 6));
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            yield return new WaitForSeconds(crruntTime);
            AddEliteEnemy();
            AddBoss();
            if (crruntTime > 0.4f)
                crruntTime -= 0.2f;
        }
    }
    void AddEliteEnemy()
    {
        if (!_bossTime)
            En2Box.EliteEnemy();
    }
    void AddBoss()
    {
        if (!_bossTime)
            Boss.EnemyBossAdd();
    }
    void rlahEl(Vector2 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            _enemyList[Count].SetActive(true);
            if (i == 0)
                _enemyList[Count].transform.position = new Vector2(dir.x, dir.y);
            else if (i == 1)
                _enemyList[Count].transform.position = new Vector2(dir.x + 0.5f, dir.y + 1);
            else if (i == 2)
                _enemyList[Count].transform.position = new Vector2(dir.x - 0.5f, dir.y + 1);
            Count++;
            if (Count > _enemyList.Count - 1) Count = 0;
        }
    }
}
