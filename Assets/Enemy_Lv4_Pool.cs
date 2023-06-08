using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv4_Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyLv4;
    private List<GameObject> _enemyLv4List = new List<GameObject>();
    private int q = 0;
    private void Awake()
    {
        GameObject qwer = Instantiate(_enemyLv4[Random.Range(0, _enemyLv4.Length)], transform);
        _enemyLv4List.Add(qwer);
        qwer.SetActive(false);
    }
    public void AddLv4(Vector3 startdir)
    {
        _enemyLv4List[q].SetActive(true);
        _enemyLv4List[q].transform.position = startdir;
        q++;
        if (q > _enemyLv4List.Count - 1) q = 0;
    }
}
