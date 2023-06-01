using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBox : MonoBehaviour
{
    [SerializeField] GameObject[] enemyBullet;
    
    public List<GameObject> enemyBulletArr = new List<GameObject>();


    private void Awake()
    {
       
        for (int i = 0; i < 300; i++)
        {
            GameObject EnBul = Instantiate(enemyBullet[Random.Range(0, enemyBullet.Length)], transform);
            enemyBulletArr.Add(EnBul);
            EnBul.SetActive(false);
        }
    }
  
}
