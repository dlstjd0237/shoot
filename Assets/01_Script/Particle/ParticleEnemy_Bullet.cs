using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnemy_Bullet : MonoBehaviour
{
    [SerializeField] GameObject[] ParticleEnemyBullet;
    public List<GameObject> particle_EnemyBulletList = new List<GameObject>();
    public int w = 0;
    private void Awake()
    {
        for (int j = 0; j < 150; j++)
        {
            GameObject asdf = Instantiate(ParticleEnemyBullet[Random.Range(0, ParticleEnemyBullet.Length)], transform);
            particle_EnemyBulletList.Add(asdf);
            asdf.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (w >particle_EnemyBulletList.Count-1)
        {
            w = 0;
        }
    }
}
