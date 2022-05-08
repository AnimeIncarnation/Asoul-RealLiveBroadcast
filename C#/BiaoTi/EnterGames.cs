using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGames : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip start;
    public AudioClip stg;


    public void ShowUI()
    {
        gameObject.SetActive(true);
        audio.clip = start;
        audio.Play();
    }
    public void End()
    {
        Application.Quit();
    }
    public void ESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        ESC();
    }

    void Start()
    {
        EventCenter.Instance.AddEvent("¿ªÊ¼ÓÎÏ·", Close);
        gameObject.SetActive(false);
        audio.clip = start;
        audio.Play();
    }

    void Close()
    {
        gameObject.SetActive(false);
        audio.clip = start;
        audio.Play();
    }
}
