using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(Co());
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
    public IEnumerator Co()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a<1.0f)
        {
            text.color = new Color(text.color.r, text.color.g ,text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(akCo());
    }
    public IEnumerator akCo()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(Co());
    }

}
