using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pool : MonoBehaviour
{
    [SerializeField] GameObject[] _powerItem;
    public int _count = 0;
    public List<GameObject> powerUpArr = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject powerUP = Instantiate(_powerItem[Random.Range(0, _powerItem.Length)], transform);
            powerUpArr.Add(powerUP);
            powerUP.SetActive(false);
        }
    }
    public void AddPowerUp(Vector3 dir)
    {
        powerUpArr[_count].SetActive(true);
        powerUpArr[_count].transform.position = dir;
        _count++;
        if (_count > powerUpArr.Count - 1) _count = 0;
    }


}
