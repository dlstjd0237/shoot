using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentTimeText;
    private IEnumerator _enemy_Spawn;
    private Enemy_Lv1_Pool _enemy_Lv1_Pool;
    private Enemy2_Box _enemy_Lv2_Pool;
    private EnemyBoos_Box _enemy_Lv3_Pool;
    private DangerScreen _dangerscreen;
    private Enemy_Lv4_Pool _enemy_Lv4_Pool;
    private BossSound _bossSound;
    private Start_Auido _start_Audio;
    private float _CurrentTime;
    private int Count = 0;
    private bool _bossSpawn = false;
    [SerializeField]
    private float _crrentTime = 1.6f;
    private void Awake()
    {
        _CurrentTime = 0;
        _enemy_Spawn = Start_Spawn();
        _bossSound = FindAnyObjectByType<BossSound>();
        _start_Audio = FindAnyObjectByType<Start_Auido>();
        _enemy_Lv1_Pool = FindAnyObjectByType<Enemy_Lv1_Pool>();
        _enemy_Lv2_Pool = FindAnyObjectByType<Enemy2_Box>();
        _enemy_Lv3_Pool = FindAnyObjectByType<EnemyBoos_Box>();
        _dangerscreen = FindAnyObjectByType<DangerScreen>();
        _enemy_Lv4_Pool = FindAnyObjectByType<Enemy_Lv4_Pool>();
    }
    public void GoSpwan()
    {
        StartCoroutine(_enemy_Spawn);
        StartCoroutine(qwer());
    }
    private bool _dangerScreenOn = false;
    private bool _rlahWl = false;
    private void Update()
    {
        _currentTimeText.text = "시간" + (int)_CurrentTime;
        if (_rlahWl == true)
            asdf();
        if (_CurrentTime > 160&& _dangerScreenOn == false)
        {
            _bossSpawn = true;
            _dangerScreenOn = true;
            StartCoroutine(Danger());
            _start_Audio.Stop();
            _bossSound.StartAudio();
            BossEnd();

        }
    }
    void asdf()
    {
        _CurrentTime += Time.deltaTime;
    }
    public void Lv1(Vector2 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            _enemy_Lv1_Pool._enemyList[Count].SetActive(true);
            if (i == 0)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x, dir.y);
            else if (i == 1)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x + 0.5f, dir.y + 1);
            else if (i == 2)
                _enemy_Lv1_Pool._enemyList[Count].transform.position = new Vector2(dir.x - 0.5f, dir.y + 1);
            Count++;
            if (Count > _enemy_Lv1_Pool._enemyList.Count - 1) Count = 0;
        }
    }
    void AddEliteEnemy()
    {
        _enemy_Lv2_Pool.EliteEnemy();
    }
    void AddBoss()
    {
        _enemy_Lv3_Pool.EnemyBossAdd();
    }
    IEnumerator qwer()
    {
        while (true)
        {
            _CurrentTime += Time.deltaTime;
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator Danger()
    {
        _dangerscreen.OpenLoadScreen();
        yield return new WaitForSeconds(2);
        _dangerscreen.OffScreen();
        _enemy_Lv4_Pool.AddLv4(new Vector3(1.23f, 10));
    }
    IEnumerator Start_Spawn()
    {
        _rlahWl = true;
        while (true)
        {
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            Lv1(new Vector2(-8, 6));
            Lv1(new Vector2(8, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(0, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);//6초
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(0, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(0, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_CurrentTime>=70)
            {
                AddEliteEnemy();
            }
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_CurrentTime >= 50)
            {
                AddEliteEnemy();
            }
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_CurrentTime >= 90)
            {
                AddEliteEnemy();
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_CurrentTime >= 80)
            {
                AddEliteEnemy();
                AddBoss();
                yield return new WaitForSeconds(_crrentTime);
            }
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_CurrentTime >= 70)
            {
                AddEliteEnemy();
                yield return new WaitForSeconds(_crrentTime);
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            Lv1(new Vector2(-8, 6));
            Lv1(new Vector2(8, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);//6초
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(0, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            if (_CurrentTime >= 30)
            {
                AddEliteEnemy();
            }
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-6, 6));
            Lv1(new Vector2(6, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_CurrentTime >= 90)
            {
                AddEliteEnemy();
            }
            Lv1(new Vector2(-10, 6));
            Lv1(new Vector2(10, 6));
            yield return new WaitForSeconds(_crrentTime);
            Lv1(new Vector2(-4, 6));
            Lv1(new Vector2(4, 6));
            Lv1(new Vector2(-2, 6));
            Lv1(new Vector2(2, 6));
            yield return new WaitForSeconds(_crrentTime);
            if (_CurrentTime >= 100)
            {
                AddEliteEnemy();
                AddBoss();
            }
            yield return new WaitForSeconds(_crrentTime);
            if (_crrentTime > 0.4f)
                _crrentTime -= 0.2f;
            if (_bossSpawn == true) break;
        }
    }
    IEnumerator BossEnd()
    {
        while (true)
        {
            AddEliteEnemy();
            yield return new WaitForSeconds(2);
            AddEliteEnemy();
            yield return new WaitForSeconds(2);
            AddEliteEnemy();
            yield return new WaitForSeconds(2);
            AddEliteEnemy();
            yield return new WaitForSeconds(4);
            AddBoss();
            yield return new WaitForSeconds(2);
        }
    }
}
