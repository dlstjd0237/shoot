using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float backGrundSpeed;

    public float Player_Attack_Speed;
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }   
}
