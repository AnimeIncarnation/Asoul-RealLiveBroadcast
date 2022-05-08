using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu1 : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip clip;

    void Awake()
    {
        EventCenter.Instance.AddEvent("Win", ShowMenu);
        EventCenter.Instance.AddEvent("Win", StopTime);
        EventCenter.Instance.AddEvent("Win", Music);
        gameObject.SetActive(false);
    }


    void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    void StopTime()
    {
        Time.timeScale = 0;
    }

    void Music()
    {
        audio.PlayOneShot(clip);
    }
}
