using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlqkf : Pool
{
    private void Awake()
    {
        ObjPool();

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Paier();
        }
    }


}
