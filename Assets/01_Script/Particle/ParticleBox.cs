using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBox : MonoBehaviour
{
    [SerializeField] GameObject[] ParticleEnemy;

    public List<GameObject> particleList = new List<GameObject>();

    public int parCoun =0;

    private void Awake()
    {
        for (int i = 0; i < 40; i++)
        {
            GameObject Par = Instantiate(ParticleEnemy[Random.Range(0, ParticleEnemy.Length)], transform);
            particleList.Add(Par);
            Par.SetActive(false);
        }
    }

}
