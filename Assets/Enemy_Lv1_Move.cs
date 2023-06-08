using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv1_Move : MonoBehaviour
{
    [SerializeField]
    private Enemy_Data _enemy_data;
    private void Update()
    {
        transform.position += Vector3.down * _enemy_data.EnemyMoveSpeed * Time.deltaTime;
        if (transform.position.y <= -10)
        {
            gameObject.SetActive(false);
        }
    }
   
}
