using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Start_Button : MonoBehaviour
{
    GameObject player;
    Transform transformPlayer;
    [SerializeField] GameObject particle;
    AudioSource Audio;
    Player_Move playermove;
    [SerializeField] Image image;
    DonDes dondes;
    private void Awake()
    {
        dondes = FindAnyObjectByType<DonDes>();
        playermove = FindAnyObjectByType<Player_Move>().GetComponent<Player_Move>();
        Audio = GetComponent<AudioSource>();
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void GameStart()
    {
        playermove.enabled = false;
        Audio.Play();
        StartCoroutine(Co());
    }
    IEnumerator Co()
    {

        GameObject dkdlt = Instantiate(particle, transformPlayer.position, Quaternion.identity);
        Destroy(dkdlt, 0.3f);
        while (true)
        {
            player.transform.position += Vector3.up * 12f * Time.deltaTime;
            if (player.transform.position.y > 12)
            {
                while (true)
                {
                    Color myCOlor = image.color;
                    myCOlor.a += 0.01f;
                    image.color = myCOlor;
                    dondes.auidoDown();
                    yield return new WaitForSeconds(0.02f);

                    if (myCOlor.a >= 1f)
                    {
                        gameObject.SetActive(true);
                        LoadingManager.LoadScene("Game");
                    }
                }


            }
            yield return null;
        }
    }
}
