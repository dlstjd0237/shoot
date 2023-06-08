using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy_child_Move : MonoBehaviour
{
    [SerializeField] float Speed = 12;
    Animator Ani;
    int p = 0;
    EliteEnemy_child_Pool child_pool;
    DistanceText distanceText;
    CapsuleCollider2D capsuleCollider2D;


    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        child_pool = FindAnyObjectByType<EliteEnemy_child_Pool>();
        Ani = GetComponent<Animator>();
        distanceText = FindAnyObjectByType<DistanceText>();
        capsuleCollider2D.enabled = true;
    }
    private void FixedUpdate()
    {
        Move();
        if (transform.position.y <= -10) gameObject.SetActive(false);

    }
    private void OnEnable()
    {

    }
    private void Move()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            capsuleCollider2D.enabled = false;
            collision.gameObject.SetActive(false);
            child_pool.AddPar(transform.position);
            distanceText.score = 100;
            CameraManeager Cam = FindAnyObjectByType<CameraManeager>();
            Cam.dkdlt(2, 0.1f);
            Ani.SetTrigger("isDie");

        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }

}
