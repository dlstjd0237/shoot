using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_CFX : MonoBehaviour
{
    new AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audio.Play();
        StartCoroutine(Co());
    }

    IEnumerator Co()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
