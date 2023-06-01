using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Die : MonoBehaviour
{

    IEnumerator Co()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
