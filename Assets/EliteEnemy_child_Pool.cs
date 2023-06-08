using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy_child_Pool : MonoBehaviour
{
    [SerializeField] private GameObject[] _child;
    [SerializeField] private GameObject[] _bullet;
    [SerializeField] private GameObject[] _par;
    public int c = 0;
    public int p = 0;
    public int b = 0;
    public List<GameObject> _childList = new List<GameObject>();
    public List<GameObject> _parList = new List<GameObject>();
    public List<GameObject> _bulletList = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject qwer = Instantiate(_child[Random.Range(0, _child.Length)], transform);
            _childList.Add(qwer);
            qwer.SetActive(false);

        }
        for (int j = 0; j < 200; j++)
        {
            GameObject asdf = Instantiate(_par[Random.Range(0, _par.Length)], transform);
            _parList.Add(asdf);
            asdf.SetActive(false);
        }
        for (int i = 0; i < 100; i++)
        {
            GameObject zxcv = Instantiate(_bullet[Random.Range(0, _bullet.Length)], transform);
            _bulletList.Add(zxcv);
            zxcv.SetActive(false);
        }
    }
    public void AddChild(Vector2 dir)
    {
        _childList[c].transform.position = dir;
        _childList[c].SetActive(true);
        c++;
        if (c > _childList.Count - 1) c = 0;
    }
    public void AddPar(Vector2 dir)
    {
        _parList[p].transform.position = dir;
        _parList[p].SetActive(true);
        p++;
        if (p > _parList.Count - 1) p = 0;
    }
    public void AddBullet(Vector2 dir)
    {
        _bulletList[b].transform.position = dir;
        _bulletList[b].SetActive(true);
        b++;
        if (b > _bulletList.Count - 1) b = 0;
    }
}
