using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraManeager : Singleton<CameraManeager>
{
    public CinemachineVirtualCamera CamV0;
    public CinemachineVirtualCamera playerCam;
    private CinemachineBasicMultiChannelPerlin CamV0_1;
    public GameObject panel;
    [SerializeField] Image ingame;


    protected override void Awake()
    {
        StartCoroutine(Ingame());
        CamV0_1 = playerCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

    }
    IEnumerator Ingame()
    {

        while (true)
        {
            Color myCOlor = ingame.color;
            myCOlor.a -= 0.05f;
            ingame.color = myCOlor;
            yield return new WaitForSeconds(0.1f);
            if (myCOlor.a <= 0) ingame.enabled = false;

        }
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
}
