using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody2D rig2D;

    [SerializeField] float playerSpeed = 7.0f;
    
    [SerializeField]Vector2 minPos;
    [SerializeField]Vector2 maxPos;

    private void Awake()
    {
    
        rig2D = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rig2D.velocity = new Vector2(x, y).normalized * playerSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), Mathf.Clamp(transform.position.y, minPos.y, maxPos.y), 0);
    }
}
