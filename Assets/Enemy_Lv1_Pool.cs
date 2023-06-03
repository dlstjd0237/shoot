using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv1_Pool : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyL1;
    public List<GameObject> _enemyList = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject qwer = Instantiate(_enemyL1[Random.Range(0, _enemyL1.Length)], transform);
            _enemyList.Add(qwer);
            qwer.SetActive(false);
        }
    }
     
    
}
