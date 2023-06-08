using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv4_Bullet_Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyBullet;
    [SerializeField]
    private List<GameObject> _enemyBulletList = new List<GameObject>();
    int q =0;
    private void Awake()
    {
        for (int i = 0; i < 500; i++)
        {
            GameObject qwer = Instantiate(_enemyBullet[Random.Range(0, _enemyBullet.Length)], transform);
            _enemyBulletList.Add(qwer);
            qwer.SetActive(false);
        }
    }

    public void SpownBullet(Vector2 startdir, Vector3 dir)
    {
        _enemyBulletList[q].SetActive(true);
        _enemyBulletList[q].transform.position = startdir;
        _enemyBulletList[q].GetComponentInChildren<Enemy_Lv4_Bullet>().ToMove(dir);
        q++;
        if (q > _enemyBulletList.Count - 1) q = 0;
    }
}
