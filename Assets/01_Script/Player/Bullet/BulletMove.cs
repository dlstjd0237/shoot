using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BulletMove : MonoBehaviour
{
    public Player_Bullet_Data player_bullet_data;
    [SerializeField] float speed = 8f;
    Transform pos;
    [SerializeField]
    Vector3 moveDir = Vector3.zero;
    void Update()
    {
        Bulletmove();
        MoveTo(moveDir);
        transform.position += moveDir * player_bullet_data.Bullet_Speed * Time.deltaTime;
    }
    private void OnDisable()
    {
        moveDir = Vector3.zero;
    }
    public void MoveTo(Vector3 dir)
    {
        moveDir = dir;
    }

    void Bulletmove()
    {
        if (transform.position.y > 25)
        {
            gameObject.SetActive(false);

        }
      
    }
}
