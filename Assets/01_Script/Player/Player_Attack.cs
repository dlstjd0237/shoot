using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Attack : Singleton<GameManager>
{
    public int _attackLvel = 1;
    public float _attackLvelTime = 0;
    [SerializeField] float delayTime = 10;
    BulletBox bulletBox;
    new AudioSource audio;
    Animator _ani;
    int q;
    protected override void Awake()
    {
        _ani = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        bulletBox = FindAnyObjectByType<BulletBox>();
    }
    private void Start()
    {
        StartCoroutine(Co());
           
    }
    private void Update()
    {
        _attackLvelTime += Time.deltaTime;
        if (_attackLvelTime >= delayTime)
        {
            if(_attackLvel>1)
            _attackLvel--;
            _attackLvelTime = 0;
        }
    }

    IEnumerator Co()
    {
        UIManeager uimaneager = FindAnyObjectByType<UIManeager>();
        int q = 0;
        while (true)
        {
            if (Input.GetKey(KeyCode.Space)|| uimaneager.m_isButtonDowning)
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
        }
    }
   
}

