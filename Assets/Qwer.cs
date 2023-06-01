using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qwer : MonoBehaviour
{
    [SerializeField] int num;
    SpriteRenderer spriteRenderer;
    [SerializeField] float tome;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (num)
        {
            case 1:
                StartCoroutine(Co(1));break;
            case 2:
                StartCoroutine(Co(2)); break;
            case 3:
                StartCoroutine(Co(3)); break;
            case 4:
                StartCoroutine(Co(4)); break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 2 * Time.deltaTime;
        if (transform.position.y < -5)
        {
            transform.position = new Vector2(0, 1);
                     
        }
    }
    IEnumerator Co(int a)
    {

        while (true) {
            if (a == 4) a = 1;
        spriteRenderer.sortingOrder = a;
            a++;
        yield return new WaitForSeconds(tome);
        spriteRenderer.sortingOrder = a;
            a++;
        yield return new WaitForSeconds(tome);
        spriteRenderer.sortingOrder = a;
            a++;
        yield return new WaitForSeconds(tome);
        spriteRenderer.sortingOrder = a;
            a = 1;
        yield return new WaitForSeconds(tome);
        }
    }
}
