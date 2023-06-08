using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{

    [SerializeField] TMP_Text text;
    float distance = 1;
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
    

}
