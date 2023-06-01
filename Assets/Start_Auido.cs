using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Auido : MonoBehaviour
{
    new AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Co());
    }

    IEnumerator Co()
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
