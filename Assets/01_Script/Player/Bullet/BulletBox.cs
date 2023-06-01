using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    public GameObject[] Bul;
    public List<GameObject> Bularr = new List<GameObject>();

    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < 300; i++)
        {
            GameObject dkdlt = Instantiate(Bul[Random.Range(0, Bul.Length)], transform);
            Bularr.Add(dkdlt);
            dkdlt.SetActive(false);
        }
    }
}
