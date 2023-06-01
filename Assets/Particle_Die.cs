using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_particle : MonoBehaviour
{
    private void OnEnable()
    {
        
    }
    IEnumerator Co()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
