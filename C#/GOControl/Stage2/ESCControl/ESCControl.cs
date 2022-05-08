using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCControl : MonoBehaviour
{
    public GameObject pannel;
    private bool isESC = false;
    public AudioSource audio;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audio.PlayOneShot(clip);
            if (isESC)
            {
                pannel.SetActive(false);
                isESC = false;
                Time.timeScale = 1;
            }
            else
            {
                pannel.SetActive(true);
                isESC = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        TryTimes.tryTimes++;
        EventCenter.Instance.Clear();
        SceneManager.LoadScene("关卡2");
    }

    public void GoBack()
    {
        Time.timeScale = 1;
        EventCenter.Instance.Clear();
        SceneManager.LoadScene("标题界面");
    }
}
