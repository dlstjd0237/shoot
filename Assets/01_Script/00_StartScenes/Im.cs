using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Im : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        StartCoroutine(Co());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Co()
    {
        while (true)
        {
            Color myCOlor = image.color;
            myCOlor.a -= 0.01f;
            image.color = myCOlor;
            yield return new WaitForSeconds(0.1f);
            if(myCOlor.a == 0.8f)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
