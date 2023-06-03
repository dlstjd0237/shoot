using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    private IEnumerator _enemy_Spawn;
    private Enemy_Lv1_Pool _enemy_Lv1_Pool;
    private Enemy2_Box _enemy_Lv2_Pool;
    private EnemyBoos_Box _enemy_Lv3_Pool;
    private int Count = 0;
    [SerializeField]
    private float _crrentTime = 1.6f;
    private void Awake()
    {
        _enemy_Spawn = Start_Spawn();
        _enemy_Lv1_Pool = FindAnyObjectByType<Enemy_Lv1_Pool>();
        _enemy_Lv2_Pool = FindAnyObjectByType<Enemy2_Box>();
        _enemy_Lv3_Pool = FindAnyObjectByType<EnemyBoos_Box>();

    }
    public void GoSpwan()
    {
        StartCoroutine(_enemy_Spawn);
    }

    public void Lv1(Vector2 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            _enemy_Lv1_Pool._enemyList[Count].SetActive(true);
            if (i == 0)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x, dir.y);
            else if (i == 1)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x + 0.5f, dir.y + 1);
            else if (i == 2)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x - 0.5f, dir.y + 1);
            Count++;
            if (Count > _enemy_Lv1_Pool._enemyList.Count - 1) Count = 0;
        }
    }
    void AddEliteEnemy()
    {
        _enemy_Lv2_Pool.EliteEnemy();
    }
    void AddBoss()
    {
        _enemy_Lv3_Pool.EnemyBossAdd();
    }
    IEnumerator Start_Spawn()
    {
        while (true)
        {
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            Lv1(new Vector2(-8, 6));
            Lv1(new Vector2(8, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);//6√ 
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(0, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
            }
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
                yield return new WaitForSeconds(_crrentTime);
            }
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
                AddBoss();
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            Lv1(new Vector2(-8, 6));
            Lv1(new Vector2(8, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);//6√ 
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(0, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
            }
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
                yield return new WaitForSeconds(_crrentTime);
            }
            if (_crrentTime <= 1)
            {
                AddEliteEnemy();
                AddBoss();
            }
            if (_crrentTime > 0.4f)
                _crrentTime -= 0.2f;
        }
    }
}
