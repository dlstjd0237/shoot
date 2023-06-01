using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv1_Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        if(transform.position.y <= -10)
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }
   
    
}
