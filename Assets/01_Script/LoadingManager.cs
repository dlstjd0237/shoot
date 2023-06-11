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

    [SerializeField]
    Image progressBar;
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _tip;
    [SerializeField] string _tip_Text;
    [SerializeField] Image _out;
    [SerializeField] Image _inGame;
    AudioSource audio;
    float timer;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");

    }
    private void Awake()
    {
        //Color myCOlor = _out.color;
        //myCOlor.a = 1;
        //_out.color = myCOlor;
        //Color myCOlor2 = _inGame.color;
        //myCOlor2.a = 0f;
        //_out.color = myCOlor2;
        audio = GetComponent<AudioSource>();
        timer = 0;
        qwer();
        asdf();
        StartCoroutine(zxcv());
        StartCoroutine(Co());


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
        progressBar.fillAmount = 0;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime * 0.15f;

            progressBar.fillAmount = Mathf.Lerp(0, 1, timer);
            if (progressBar.fillAmount >= 1f)
            {
                while (true)
                {

                    audio.volume -= 0.002f;
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
    IEnumerator Co()
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
    void qwer()
    {
        Color myCOlor = _out.color;
        myCOlor.a += 1f;
        _out.color = myCOlor;
    }
    void asdf()
    {
        Color myCOlor = _inGame.color;
        myCOlor.a -= 1f;
        _inGame.color = myCOlor;
    }
    IEnumerator zxcv()
    {
        while (true)
        {

            audio.volume += 0.002f;
            yield return new WaitForSeconds(0.01f);
            if (audio.volume >= 0.3f) break;
        }
    }
}
