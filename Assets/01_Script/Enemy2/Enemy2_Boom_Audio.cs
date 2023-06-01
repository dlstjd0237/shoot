using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Boom_Audio : MonoBehaviour
{
    AudioSource Audio;
    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        Audio.Play();
        StartCoroutine(Co());
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.down*1*Time.deltaTime; 
    }
    IEnumerator Co()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
