using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] protected GameObject[] PoolObj;
    [SerializeField] protected int PoolCount;
    [SerializeField] protected float Fire;
    public List<GameObject> Poolarr = new List<GameObject>();

    public void ObjPool()
    {
        for (int i = 0; i < PoolCount; i++)
        {
            GameObject rlahEl = Instantiate(PoolObj[Random.Range(0, PoolObj.Length)], transform);
            Poolarr.Add(rlahEl);
            rlahEl.SetActive(false);
        }
    }

    public void Paier()
    {
        StartCoroutine(StartPoolling());
    }

    public IEnumerator StartPoolling()
    {
        int q = 0;
        Poolarr[q].SetActive(true);
        Poolarr[q].transform.position = transform.position;
        yield return new WaitForSeconds(Fire);
        q++;
        if (q > Poolarr.Count - 1)
        {
            q = 0;
        }
    }

}
