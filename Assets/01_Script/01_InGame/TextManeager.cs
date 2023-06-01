using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManeager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] string[] comamt1;
    [SerializeField] string[] comamt2;
    [SerializeField] float cool;
    [SerializeField] float nextTextCool;
    [SerializeField] GameObject panel;
    [SerializeField] AudioSource _gameAudio;
    DistanceText _distanceText;
    new AudioSource audio;
    GameObject dkdlt;
   


    int count = 0;
    private void Awake()
    {
        _distanceText = GetComponent<DistanceText>();
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        int comamtCount = comamt1.Length;
        StartText1();
    }
    public void StartText1()
    {
        StartCoroutine(Co(comamt1[count], cool, count));
    }
    public void StartText2()
    {
        panel.gameObject.SetActive(true);
        StartCoroutine(Co2(comamt2[count], cool, count));
    }
    IEnumerator Co(string b, float c, int a)
    {
        text.text = null;
        audio.Play();
        for (int i = 0; i < b.Length; i++)
        {
            
            text.text += b[i];
            yield return new WaitForSeconds(c);
        }
        audio.Stop();
        yield return new WaitForSeconds(nextTextCool);
        count++;
        if (count >= comamt1.Length)
        {
            CameraManeager camerManeager = FindAnyObjectByType<CameraManeager>();
            camerManeager.tlqkf();
            count = 0;
            //panel.gameObject.SetActive(false);
            //EnemyBox enemyBox = FindAnyObjectByType<EnemyBox>();
            //enemyBox.EnemySpown();
        }
        else
        {
            StartCoroutine(Co(comamt1[count], cool, count));
        }
    }
    IEnumerator Co2(string b, float c, int a)
    {
        text.text = null;
        audio.Play();
        for (int i = 0; i < b.Length; i++)
        {

            text.text += b[i];
            yield return new WaitForSeconds(c);
        }
        audio.Stop();
        yield return new WaitForSeconds(nextTextCool);
        count++;
        if (count >= comamt2.Length)
        {
            count = 0;
            panel.gameObject.SetActive(false);
            _distanceText.enabled = true;
            _gameAudio.Play();
            StartCoroutine(qw());
            EnemyBox enemyBox = FindAnyObjectByType<EnemyBox>();
            enemyBox.EnemySpown();
            Enemy_Lv1_Pool enemy_Lv1_Pool = FindAnyObjectByType<Enemy_Lv1_Pool>();
            enemy_Lv1_Pool.Spawn();

        }
        else
        {
            StartCoroutine(Co2(comamt2[count], cool, count));
        }
        IEnumerator qw()
        {
            while (true)
            {
                audio.volume += 0.002f;
                yield return new WaitForSeconds(0.01f);
                if (audio.volume >= 0.2f) break;
            }
            yield return null;
        }
    }
}
