using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{

    [SerializeField] TMP_Text text;
    float distance = 1;
    bool a = false;
    bool b = false;
    float time = 0;
    public float score
    {
        get => distance;
        set => distance+=Mathf.Max(0, value);
    }
    private void Awake()
    {
        enabled = false;
    }
    void Update()
    {
        Plus();
        //StartCoroutine(enemy());
        //StartCoroutine(boss());
        time += Time.deltaTime;

    }
    void Plus()
    {
        distance += Time.deltaTime;
        text.text = $"Score : { (int)distance}";
    }
    //public void AddScore(int score)
    //{
    //    distance += score;
    //}
    IEnumerator enemy()
    {
        if (a == false)
        {


            if ((int)time % 10 == 0)
            {
                a = true;
                Enemy2_Box En2Box = FindAnyObjectByType<Enemy2_Box>();
                En2Box.EliteEnemy();

                yield return new WaitForSeconds(1);
                a = false;

            }

        }
    }
    IEnumerator boss()
    {
        if (b == false)
        {


            if ((int)time % 30 == 0)
            {
                b = true;
                EnemyBoos_Box Boss = FindAnyObjectByType<EnemyBoos_Box>();
                Boss.EnemyBossAdd();

                yield return new WaitForSeconds(1);
                b = false;

            }

        }
    }

    private void BossAdd()
    {
        if ((int)distance % 500 == 0)
        {

            EnemyBoos_Box Boss = FindAnyObjectByType<EnemyBoos_Box>();

            Boss.EnemyBossAdd();
        }
    }

}
