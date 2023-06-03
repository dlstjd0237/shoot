using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option_Button : MonoBehaviour
{
    [SerializeField] GameObject Option_Panel;
    private bool _optioncheck = false;
    private bool _soundCheck = false;
    [SerializeField] private Image _defaultImage;
    [SerializeField] private Image _onSuond;
    [SerializeField] private Image _offSuond;
    private void Awake()
    {
        //_defaultImage = GameObject.Find("Canvas/Option_Panel/Audio").GetComponent<Image>();
        //_onSuond = GameObject.Find("Canvas/Option_Panel/SoundOn").GetComponent<Image>();
        //_offSuond = GameObject.Find("Canvas/Option_Panel/SoundOff").GetComponent<Image>();
    }
    public void SetSound()
    {

            AudioListener.volume = 0;
            _onSuond.enabled = false;
            _offSuond.enabled = true;
 


    }
    public void OutSound()
    {
        AudioListener.volume = 1;
        _offSuond.enabled = true;
        _onSuond.enabled = false;

    }

    public void inOption()
    {
        if (_optioncheck == false)
        {
            Option_Panel.SetActive(true);
            _optioncheck = true;
            Time.timeScale = 0;
        }
        else if (_optioncheck == true)
        {
            Option_Panel.SetActive(false);
            _optioncheck = false;
            Time.timeScale = 1;
        }
    }

    public void goMain()
    {
        Time.timeScale = 1;
        LoadingManager.LoadScene("Start");
    }
    public void gameEnd()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inOption();
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                inOption();
            }
        }
    }
}
