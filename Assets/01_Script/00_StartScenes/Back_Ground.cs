using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Ground : Singleton<GameManager>
{
    private void Update()
    {

        if (transform.position.y < -15)
        {
            transform.position = new Vector2(0, 25);
        }
        transform.position += Vector3.down * GameManager.instance.backGrundSpeed * Time.deltaTime;
        
    }


}
