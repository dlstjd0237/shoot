using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_data",menuName = "ScriptableObject/Enemy_data", order = 1)]
public class Enemy_Data : ScriptableObject
{
    [SerializeField] private float _enemyMoveSpeed;
    [SerializeField] private float _enemyHp;
    [SerializeField] private float _enemyBulletSpeed;
    public float EnemyMoveSpeed { get { return _enemyMoveSpeed; } }
    public float EnemyHp { get { return _enemyHp; } }
    public float EnemyBulletSpeed { get { return _enemyBulletSpeed; } }
}
