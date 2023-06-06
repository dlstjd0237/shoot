using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player_Bullet_Data", order = int.MaxValue)]
public class Player_Bullet_Data : ScriptableObject
{
    [SerializeField]
    private float _bullet_Speed;

    public float Bullet_Speed
    {
        get { return _bullet_Speed; }
    }

}
