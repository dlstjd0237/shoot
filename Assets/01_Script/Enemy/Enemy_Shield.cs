using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    public Player_Bullet_Data Bullet;

    Vector3 moveDir = Vector3.zero;
    void Update()
    {
        Bulletmove();
        MoveTo(moveDir);
        transform.position += moveDir * Bullet.Bullet_Speed * Time.deltaTime;
    }
    private void Start()
    {
        StartCoroutine(Co());
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
    IEnumerator Co()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
