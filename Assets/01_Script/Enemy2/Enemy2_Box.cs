using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Box : MonoBehaviour
{
    [SerializeField]GameObject[] Enemy2;
    List<GameObject> Enemy2List = new List<GameObject>();
    int q = 0;
    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject eliteEnemy = Instantiate(Enemy2[Random.Range(0, Enemy2.Length)], transform);
            Enemy2List.Add(eliteEnemy);
            eliteEnemy.SetActive(false);
        }
    }
    public void EliteEnemy()
    {
        Enemy2List[q].SetActive(true);
        Enemy2List[q].transform.position = new Vector2(Random.Range(-9, 11.5f), 5.7f);
        q++;
        if (q >Enemy2List.Count-1)
        {
            q = 0;
        }
    }
}
