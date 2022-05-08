using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWin : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;

    void Start()
    {
        EventCenter.Instance.AddEvent("Win!", Win);
        EventCenter.Instance.AddEvent("Win!", Sound);
        gameObject.SetActive(false);
    }

    void Win()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void Sound()
    {
        audio.PlayOneShot(clip);
    }
}
