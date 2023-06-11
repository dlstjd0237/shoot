using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class DangerScreen : MonoBehaviour
{
    
    private Image _image;
    private RectTransform _rectTrm;
    private Vector2 _screenSize;
    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _screenSize = new Vector2(Screen.width, Screen.height);
        _rectTrm.sizeDelta = _screenSize;
        _rectTrm.anchoredPosition = new Vector2(0, Screen.height);
    }
 
    public void OpenLoadScreen()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_rectTrm.DOAnchorPosY( 0,0.5f));
        seq.Join(_image.DOFade(0.7f, 0.5f));
    }
    public void OffScreen()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_rectTrm.DOAnchorPosY(_screenSize.y, 0.5f));
        seq.Join(_image.DOFade(0f, 0.5f));
    }
}
