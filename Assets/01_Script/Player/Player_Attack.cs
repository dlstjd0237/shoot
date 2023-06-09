using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Attack : Singleton<GameManager>
{
    [SerializeField]
    int _attackLvel = 1;
    int _attackLvel_bar_max = 500;
    bool _tl = false;
    bool _t2 = false;
    bool _t3 = false;
    [SerializeField]
    int _currentAttackLvel_bar = 0;
    //public float _attackLvelTime = 0;
    //[SerializeField] private float delayTime = 10;
    private BulletBox bulletBox;
    private Player_Lv6_Bullet_Pool bulletBox2;
    private Player_Move _playerMove;
    new AudioSource audio;
    Animator _ani;
    int q;
    public int Attack_Bar_Max
    {
        get => _attackLvel_bar_max;
        set => _attackLvel_bar_max += Mathf.Max(0, value);
    }
    public int CurrentAttack_bar
    {
        get => _currentAttackLvel_bar;
        set
        {
            if (value == 0)
            {
                _currentAttackLvel_bar = 0;
            }
            else
            {

                _currentAttackLvel_bar += Mathf.Max(0, value);
            }

        }
    }
    public int AttackLvel
    {
        get => _attackLvel;
        set => _attackLvel += Mathf.Max(0, value);
    }
    protected override void Awake()
    {
        _playerMove = FindAnyObjectByType<Player_Move>();
        _ani = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        bulletBox2 = FindAnyObjectByType<Player_Lv6_Bullet_Pool>();
        bulletBox = FindAnyObjectByType<BulletBox>();
    }
    private void Start()
    {
        StartCoroutine(Co());

    }
    private void Update()
    {
        if (_attackLvel == 8) _currentAttackLvel_bar = 0;

    }

    IEnumerator Co()
    {
        UIManeager uimaneager = FindAnyObjectByType<UIManeager>();
        int q = 0;
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) || uimaneager.m_isButtonDowning && _playerMove.die == false)
            {
                _ani.SetBool("isAttack", true);
                audio.Play();
                AttackLv();
                yield return new WaitForSeconds(GameManager.instance.Player_Attack_Speed);
                if (q > bulletBox.Bularr.Count - 1)
                {
                    q = 0;
                }
            }
            else _ani.SetBool("isAttack", false);
            yield return null;
        }
    }
    public void AttackLv()
    {
        switch (_attackLvel)
        {
            case 1:
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = transform.position;
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                break;
            case 2:
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                break;
            case 3:
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = transform.position;
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0.2f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(-0.2f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                break;
            case 4:
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = transform.position;
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0.2f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(-0.2f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(-0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                break;
            case 5:
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(-0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(-0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                bulletBox.Bularr[q].SetActive(true);
                bulletBox.Bularr[q].transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y);
                bulletBox.Bularr[q].GetComponentInChildren<BulletMove>().MoveTo(new Vector3(0.1f, 1, 0));
                q += 1;
                if (q > bulletBox.Bularr.Count - 1) q = 0;
                break;
            case 6:
                bulletBox.Spwan(transform.position, new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.2f, transform.position.y), new Vector3(0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.4f, transform.position.y), new Vector3(0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.4f, transform.position.y), new Vector3(-0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.2f, transform.position.y), new Vector3(-0.1f, 1, 0));
                if (_tl == false)
                    StartCoroutine(fountain());
                break;
            case 7:

                bulletBox.Spwan(transform.position, new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.2f, transform.position.y), new Vector3(0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.3f, transform.position.y), new Vector3(0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.4f, transform.position.y), new Vector3(0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.4f, transform.position.y), new Vector3(-0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.3f, transform.position.y), new Vector3(-0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.2f, transform.position.y), new Vector3(-0.1f, 1, 0));
                if (_t2 == false)
                    StartCoroutine(fountain2());
                break;
            case 8:
                bulletBox.Spwan(transform.position, new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.1f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.2f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.2f, transform.position.y), new Vector3(0, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.2f, transform.position.y), new Vector3(0.05f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.3f, transform.position.y), new Vector3(0.75f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x + 0.4f, transform.position.y), new Vector3(0.1f, 1, 0));
                if (_t3 == false)
                    StartCoroutine(fountain3());
                bulletBox.Spwan(new Vector3(transform.position.x - 0.4f, transform.position.y), new Vector3(-0.1f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.3f, transform.position.y), new Vector3(-0.75f, 1, 0));
                bulletBox.Spwan(new Vector3(transform.position.x - 0.2f, transform.position.y), new Vector3(-0.05f, 1, 0));
                break;
        }
    }
    IEnumerator fountain3()
    {
        _t3 = true;
        float weightAngle = 0;
        while (true)
        {

            for (int i = 0; i < 20; i++)
            {
                float angle = weightAngle + 360 / 20 * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                bulletBox2.AddBullet(transform.position, new Vector3(x, y));
            }
            //weightAngle += 1;
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator fountain2()
    {
        _t2 = true;
        float weightAngle = 0;
        while (true)
        {

            for (int i = 0; i < 20; i++)
            {
                float angle = weightAngle + 360 / 20 * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                bulletBox2.AddBullet(transform.position, new Vector3(x, y));
            }
            //weightAngle += 1;
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator fountain()
    {
        _tl = true;
        float weightAngle = 0;
        while (true)
        {

            for (int i = 0; i < 20; i++)
            {
                float angle = weightAngle + 360 / 20 * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                bulletBox2.AddBullet(transform.position, new Vector3(x, y));
            }
            //weightAngle += 1;
            yield return new WaitForSeconds(3);
        }
    }
}

