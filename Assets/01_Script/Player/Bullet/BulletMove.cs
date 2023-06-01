using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    Transform pos;
    [SerializeField]
    Vector3 moveDir = Vector3.zero;
    void Update()
    {
        Bulletmove();
        MoveTo(moveDir);
        transform.position += moveDir * speed * Time.deltaTime;
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
