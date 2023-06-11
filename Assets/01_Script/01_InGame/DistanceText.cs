using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistanceText : MonoBehaviour
{

    [SerializeField] TMP_Text text;
    float distance = 0;


    public static Action EndScore;
    private void Awake()
    {
        EndScore = () => { SetScore(); };
    }
    public float score
    {
        get => distance;
        set => distance+=Mathf.Max(0, value);
    }
    void Update()
    {
        Plus();
    }
    void Plus()
    {
        text.text = $"Score : { (int)distance}";
       
    }
    public void SetScore()
    {
        PlayerPrefs.SetFloat("Current_Score", score);
    }
    

}
