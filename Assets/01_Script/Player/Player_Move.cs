using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Move : MonoBehaviour
{
    
    Rigidbody2D rig2D;
    Animator Ani;
    private CameraManeager _camManeager; 
    [SerializeField] float playerSpeed = 7.0f;
    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;
    [SerializeField] Image ingame;
    public bool die = false;

    private void Awake()
    {
        _camManeager = FindAnyObjectByType<CameraManeager>();
        Ani = GetComponent<Animator>();
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
        if (die == false)
            rig2D.velocity = new Vector2(x, y).normalized * playerSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), Mathf.Clamp(transform.position.y, minPos.y, maxPos.y), 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy") && die == false)
        {
            die = true;
            StartCoroutine(a());
        }
    }
    public void Die()
    {
        Time.timeScale = 1;
        _camManeager.gameover();
        DistanceText.EndScore();
        gameObject.SetActive(false);

    }
    IEnumerator a()
    {
        _camManeager.DieCam(4, 3);
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0.5f;
        _camManeager.DieCam(8, 2);
        Ani.SetTrigger("isDie");
    }
   
}
