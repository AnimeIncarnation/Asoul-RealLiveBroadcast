using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TellStory : MonoBehaviour
{
    public GameObject video;
    public bool ESCjudge = false;
    public AudioSource audio;
    public AudioClip clip;
    
    void Start()
    {
        EventCenter.Instance.AddEvent("开始游戏", Open);
        gameObject.SetActive(false);
    }

    void Open()
    {
        gameObject.SetActive(true);
    }

    public void Continue()
    {
        video.SetActive(true);
        StartCoroutine(GameStart());
        audio.clip = clip;
        audio.PlayOneShot(clip);
    }

    IEnumerator GameStart()
    {
        ESCjudge = true;
        yield return new WaitForSeconds(27);
        if (RayTest.state == 2)
        {
            SceneManager.LoadScene("关卡2");
        }
        else if(RayTest.state == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    void Update()
    {
        if (ESCjudge)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StopAllCoroutines();
                if (RayTest.state == 2)
                {
                    SceneManager.LoadScene("关卡2");
                }
                else if(RayTest.state == 1)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}
