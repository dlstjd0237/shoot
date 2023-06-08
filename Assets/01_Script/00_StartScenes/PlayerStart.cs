using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerStart : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        DOTween.SetTweensCapacity(3000,3000);
        audioSource = GetComponent<AudioSource>();
    }

    public void cameraMove()
    {
        audioSource.Play();
        transform.position += Vector3.down * 3 * Time.deltaTime;
    }
}
