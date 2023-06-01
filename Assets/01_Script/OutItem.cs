using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutItem : MonoBehaviour
{
    [SerializeField] int _percent;
    int q = 0;

    void Additem()
    {
        if (Random.Range(0, 101) < _percent)
        {
            Item_Pool item_pool = FindAnyObjectByType<Item_Pool>();
            item_pool.powerUpArr[q].SetActive(true);
            item_pool.powerUpArr[q].transform.position = transform.position;
            q++;
            if (q > item_pool.powerUpArr.Count - 1) q = 0;
        }
    }
}
