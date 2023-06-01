using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lv1_Particle_Pool : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy_Lv1_Particle;
    List<GameObject> enemy_Lv1_Particle_List = new List<GameObject>();
    int q = 0;
    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject qwer = Instantiate(enemy_Lv1_Particle[Random.Range(0, enemy_Lv1_Particle.Length)], transform);
            enemy_Lv1_Particle_List.Add(qwer);
            qwer.SetActive(false);
        }
    }
    public void AddParticle(Vector2 dir)
    {
        enemy_Lv1_Particle_List[q].transform.position = dir;
        enemy_Lv1_Particle_List[q].SetActive(true);
        q += 1;
        if (q > enemy_Lv1_Particle_List.Count - 1) q = 0;
    }
}
