using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Button : MonoBehaviour
{
    [SerializeField] GameObject Option_Panel;
    bool Optioncheck = false;
    public void SundOut()
    {
        AudioListener.volume = 0;
    }
    
    public void inOption()
    {
        if(Optioncheck == false)
        {
            Option_Panel.SetActive(true);
            Optioncheck = true;
            Time.timeScale = 0;
        }
        else if(Optioncheck == true)
        {
            Option_Panel.SetActive(false);
            Optioncheck = false;
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
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                inOption();
            }
        }
    }
}
