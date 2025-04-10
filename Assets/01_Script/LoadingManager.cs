using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LoadingManager : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image _progressBar;
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _tip;
    [SerializeField] string _tip_Text;
    [SerializeField] Image _out;
    [SerializeField] Image _inGame;
    AudioSource _audio;
    float _timer;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");

    }
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _timer = 0;
        OutColorChange();
        InGameColorChange();
        StartCoroutine(VolumeChangeCoroutine());
        StartCoroutine(OutColorChangeCoroutine());


    }

    private void Start()
    {
        StartCoroutine(LoadingSceneprocess());
        _tip.text = "" + _tip_Text;
    }
    private void FixedUpdate()
    {
        float q = progressBar.fillAmount * 100;
        _text.text = (int)q + "%";
    }
    IEnumerator LoadingSceneprocess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        //op.progress = 0f;
        _progressBar.fillAmount = 0;
        while (!op.isDone)
        {
            yield return null;
            _timer += Time.deltaTime * 0.30f;

            _progressBar.fillAmount = Mathf.Lerp(0, 1, timer);
            if (progressBar.fillAmount >= 1f)
            {
                while (true)
                {

                    _audio.volume -= 0.002f;
                    Color myCOlor = _inGame.color;
                    myCOlor.a += 0.02f;
                    _inGame.color = myCOlor;
                    yield return new WaitForSeconds(0.01f);
                    if (audio.volume <= 0.01f)
                    {
                        //dondes.DestroyObj();
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }

            }
        }
    }
    IEnumerator OutColorChangeCoroutine()
    {
        while (true)
        {
            Color myCOlor = _out.color;
            myCOlor.a -= 0.04f;
            _out.color = myCOlor;
            yield return new WaitForSeconds(0.05f);
            if (myCOlor.a == 0) break;

        }
    }
    void OutColorChange()
    {
        Color myCOlor = _out.color;
        myCOlor.a += 1f;
        _out.color = myCOlor;
    }
    void InGameColorChange()
    {
        Color myCOlor = _inGame.color;
        myCOlor.a -= 1f;
        _inGame.color = myCOlor;
    }
    IEnumerator VolumeChangeCoroutine()
    {
        while (true)
        {

            _audio.volume += 0.002f;
            yield return new WaitForSeconds(0.01f);
            if (_audio.volume >= 0.3f) break;
        }
    }
}
