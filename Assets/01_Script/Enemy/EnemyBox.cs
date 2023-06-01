using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;
    List<GameObject> Enemyarr = new List<GameObject>();
    [SerializeField] float spawncool;
    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {

            GameObject dkdlt = Instantiate(Enemy[Random.Range(0, Enemy.Length)], transform);
            Enemyarr.Add(dkdlt);
            dkdlt.SetActive(false);
        }

    }
    public void EnemySpown()
    {
        StartCoroutine(Co());
    }
    IEnumerator Co()
    {
        int q = 0;
        while (true)
        {
            Enemyarr[q].SetActive(true);
            Enemyarr[q].transform.position = new Vector2(Random.Range(-11, 12),20);
            q += 1;
            yield return new WaitForSeconds(spawncool);
            if (q>Enemyarr.Count-1)
            {
                q = 0;
            }
        }
    }
}
