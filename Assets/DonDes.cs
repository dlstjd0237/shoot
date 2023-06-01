using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDes : MonoBehaviour
{
    public AudioSource auido;
    private void Awake()
    {
        auido = GetComponent<AudioSource>();
    }
    void Start()
    {
        auido.volume = 0;
        StartCoroutine(Co());
    }
    //public void DestroyObj()
    //{
    //    gameObject.SetActive(false);
    //}
    IEnumerator Co()
    {
        auido.volume +=0.01f;
        if (auido.volume >= 0.15f) StopAllCoroutines();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Co());
    }
    public void auidoDown()
    {
        auido.volume -= 0.002f;

    }



}
