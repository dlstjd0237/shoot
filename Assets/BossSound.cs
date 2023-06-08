using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void StartAudio()
    {
        StartCoroutine(Co());
    }
    IEnumerator Co()
    {
        _audio.Play();
        for (int i = 0; i < 30; i++)
        {
            _audio.volume += 0.012f;
            yield return new WaitForSeconds(0.02f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
