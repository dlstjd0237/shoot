using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Move : MonoBehaviour
{
    [SerializeField] float speed;
    DistanceText Setscore;
    Transform player;
    private void Awake()
    {
        Setscore = FindAnyObjectByType<DistanceText>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
        if (Random.Range(0, 101) <= 30)
        {
            transform.DOMove(player.position, 3);
            
        }
    }
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;


        if (transform.position.y < -7)
        {
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {           
            collision.gameObject.SetActive(false);
            AddPrti();
            Additem();
            Setscore.score = 50;
            gameObject.SetActive(false);
        }
    }
    void AddPrti()
    {
        ParticleBox Parti = FindAnyObjectByType<ParticleBox>();
        Parti.particleList[Parti.parCoun].SetActive(true);
        Parti.particleList[Parti.parCoun].transform.position = transform.position;
        Parti.parCoun++;
        if (Parti.parCoun > Parti.particleList.Count - 1) Parti.parCoun = 0;
    }
    void Additem()
    {
        if (Random.Range(0, 101) <= 5)
        {
            Item_Pool item_pool = FindAnyObjectByType<Item_Pool>();
            item_pool.AddPowerUp(transform.position);

        }
    }


}
