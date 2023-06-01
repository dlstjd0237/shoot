using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_CFX_Boom_Box : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy2_Boom;
    public List<GameObject> _enemy_BoomArr = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {

            GameObject asdf = Instantiate(_enemy2_Boom[Random.Range(0, _enemy2_Boom.Length)], transform);
            _enemy_BoomArr.Add(asdf);
            asdf.SetActive(false);
        }
    }


}
