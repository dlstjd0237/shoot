using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SocreUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _currntScoreText;
    [SerializeField]
    private TMP_Text _highScoreText;
    [SerializeField]
    private GameObject _gameOverPanel;
    private DistanceText distanceText;
    public static Action Game_over_Panel;
    private float _currentScore = 0;
    private float _highScore = 0;

    private void Awake()
    {
        Game_over_Panel = () => { Gameover(); };
        distanceText = FindAnyObjectByType<DistanceText>();

    }
    int c = 0;
    public void Gameover()
    {
        if (c != 0)
            PlayerPrefs.GetFloat("HighScore", _highScore);
        _currentScore = distanceText.score;
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        if (distanceText.score > _highScore)
        {
            PlayerPrefs.SetFloat("HighScore", _highScore);
            _highScore = _currentScore;
        }
        c++;
        _currntScoreText.text = "내 점수 : " + _currentScore;
        _highScoreText.text = "점수를 기억하십시오 최고점수는\n 시간이없어 못했습니다.";
    }
}
