using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lv6_Bullet_Pool : MonoBehaviour
{
    [SerializeField]
    GameObject[] _player_bullet;
    List<GameObject> _player_bullet_list = new List<GameObject>();
    int q = 0;
    private void Awake()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject qwer = Instantiate(_player_bullet[Random.Range(0, _player_bullet.Length)], transform);
            _player_bullet_list.Add(qwer);
            qwer.SetActive(false);
        }
    }
    public void AddBullet(Vector3 w,Vector3 e)
    {
        _player_bullet_list[q].SetActive(true);
        _player_bullet_list[q].transform.position = w;
        _player_bullet_list[q].GetComponentInChildren<Enemy_Shield>().MoveTo(e);
        q += 1;
        if (q > _player_bullet_list.Count - 1) q = 0;
    }
}
