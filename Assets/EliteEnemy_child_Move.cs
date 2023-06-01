using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy_child_Move : MonoBehaviour
{
    [SerializeField] float Speed = 12;
    Animator Ani;
    int p=0;
    EliteEnemy_child_Pool child_pool;
    DistanceText distanceText;

    private void Awake()
    {
        child_pool = FindAnyObjectByType<EliteEnemy_child_Pool>(); 
        Ani = GetComponent<Animator>();
        distanceText = FindAnyObjectByType<DistanceText>();
    }
    private void FixedUpdate()
    {
        Move();
        if (transform.position.y <= -10) gameObject.SetActive(false);

    }

    private void Move()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
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
