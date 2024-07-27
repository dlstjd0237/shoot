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
    [SerializeField] float playerMoveSpeed = 10.0f;
    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;
    [SerializeField] Image ingame;
    public bool die = false;
    public bool _godMode = false;


    private void Awake()
    {
        _camManeager = FindAnyObjectByType<CameraManeager>();
        Ani = GetComponent<Animator>();
        rig2D = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate()
    {
        Move();

        //if (Input.GetKeyDown(KeyCode.O))
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rig2D.velocity = new Vector2(x, y).normalized * playerMoveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), Mathf.Clamp(transform.position.y, minPos.y, maxPos.y), 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("EnemyBullet") && die == false && _godMode == false) || (collision.CompareTag("Enemy") && die == false && _godMode == false))
        {
            die = true;
            StartCoroutine(DieCameraSet());
        }
    }
    public void Die()
    {
        Time.timeScale = 1;
        _camManeager.gameover();
        DistanceText.EndScore();
        gameObject.SetActive(false);

    }
    IEnumerator DieCameraSet()
    {
        _camManeager.DieCam(4, 3);
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0.5f;
        _camManeager.DieCam(8, 2);
        Ani.SetTrigger("isDie");
    }

}
