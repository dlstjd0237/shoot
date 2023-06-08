using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Exp_bar : MonoBehaviour
{
    private Image _exp_bar;
    private float q;
    private float w;
    private float currenLvel;
    private bool qwer;
    [SerializeField]
    private TMP_Text _currentExpBar;
    [SerializeField]
    private TMP_Text _currentLv;
    Player_Attack player_attack;
    

    private void Awake()
    {
        qwer = false;
        player_attack = FindAnyObjectByType<Player_Attack>();
        _exp_bar = GetComponent<Image>();
    }
    // Update is called once per frame
    float dkdlt;
    void Update()
    {
        q = player_attack.Attack_Bar_Max;
        w = player_attack.CurrentAttack_bar;
        LvUpText();
        currenLvel = w / q;
        dkdlt = currenLvel * 100;
        _currentExpBar.text = (int)dkdlt + "%";
        _exp_bar.DOFillAmount(currenLvel, 0.4f);
        Re_Set();

    }
    void LvUpText()
    {
        _currentLv.text = "Lv." + player_attack.AttackLvel;
    }
    private void Re_Set()
    {
        if (currenLvel >= 0.99999f)
        {
            player_attack.CurrentAttack_bar = 0;
            player_attack.AttackLvel = 1;
            player_attack.Attack_Bar_Max = 250;
            Debug.Log(player_attack.AttackLvel);
            Debug.Log(player_attack.CurrentAttack_bar);
            Debug.Log(player_attack.Attack_Bar_Max);
        }
    }
}
