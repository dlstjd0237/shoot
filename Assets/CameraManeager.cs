using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraManeager : Singleton<CameraManeager>
{
    public CinemachineVirtualCamera CamV0;
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera playerDieCam;
    private CinemachineBasicMultiChannelPerlin CamV1_1;
    private CinemachineBasicMultiChannelPerlin CamV0_1;
    public GameObject panel;
    [SerializeField] Image ingame;
    

    protected override void Awake()
    {
        StartCoroutine(Ingame());
        CamV0_1 = playerCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        CamV1_1 = playerDieCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }
    IEnumerator Ingame()
    {

        while (true)
        {
            Color myCOlor = ingame.color;
            myCOlor.a -= 0.03f;
            ingame.color = myCOlor;
            yield return new WaitForSeconds(0.1f);
            if (myCOlor.a <= 0)
            {
                ingame.enabled = false;
                break;
            }
        }
    }
    IEnumerator ountIngame()
    {
        ingame.enabled = true;
        while (true)
        {
            Color myCOlor = ingame.color;
            myCOlor.a += 0.04f;
            ingame.color = myCOlor;
            yield return new WaitForSeconds(0.1f);
            if (myCOlor.a >= 1)
            {
                SocreUI.Game_over_Panel();
                break;
            }
        }
    }
    public void gameover()
    {
        StartCoroutine(ountIngame());
    }
    public void tlqkf()
    {
        StartCoroutine(qwer());
    }
    public IEnumerator qwer()
    {

        CamV0.Priority = 15;
        yield return new WaitForSeconds(3);
        CamV0.Priority = 9;
        panel.gameObject.SetActive(false);
        TextManeager textManeager = FindAnyObjectByType<TextManeager>();
        textManeager.StartText2();

    }
    public void dkdlt(int power, float Time)
    {
        StartCoroutine(Co(power, Time));
    }
    IEnumerator Co(int power, float Time)
    {
        CamV0_1.m_AmplitudeGain = power;
        CamV0_1.m_FrequencyGain = power;
        yield return new WaitForSeconds(Time);
        CamV0_1.m_AmplitudeGain = 0f;
        CamV0_1.m_FrequencyGain = 0f;
    }
    public void DieCam(float power, float Time)
    {
        playerDieCam.Priority = 11;
        StartCoroutine(qwer(power, Time));
    }
    IEnumerator qwer(float power, float Time)
    {
        CamV1_1.m_AmplitudeGain = power;
        CamV1_1.m_FrequencyGain = power;
        yield return new WaitForSeconds(Time);
        CamV1_1.m_AmplitudeGain = 0;
        CamV1_1.m_FrequencyGain = 0;
    }
}
