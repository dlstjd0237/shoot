using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    public GameObject[] Bul;
    public List<GameObject> Bularr = new List<GameObject>();
    int q = 0;
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
    public void Spwan(Vector3 spwandir, Vector3 godir)
    {
        Bularr[q].SetActive(true);
        Bularr[q].transform.position = spwandir;
        Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(godir);
        q++;
        if (q > Bularr.Count - 1) q = 0;
    }
}
