using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENemy2_CFXBox : MonoBehaviour
{
    [SerializeField] GameObject[] CFX;
    public List<GameObject> CFXarr = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject dk = Instantiate(CFX[Random.Range(0, CFX.Length)], transform);
            CFXarr.Add(dk);
            dk.SetActive(false);
        }
    }
}
