using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoos_Box : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyBoss;
    List<GameObject> _enemyBossArr = new List<GameObject>();
    int q = 0;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject dk = Instantiate(_enemyBoss[Random.Range(0, _enemyBoss.Length)], transform);
            _enemyBossArr.Add(dk);
            dk.SetActive(false);
        }

    }
    public void EnemyBossAdd()
    {

        _enemyBossArr[q].SetActive(true);
        _enemyBossArr[q].transform.position = new Vector2(-19, 9);
        _enemyBossArr[q].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

        q++;
        if (q > _enemyBossArr.Count - 1) q = 0;
    }
}
