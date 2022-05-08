using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASoulMusic : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;

    void Start()
    {
        EventCenter.Instance.AddEvent("ASoulMusic",Music);
    }

    // Update is called once per frame
    void Music()
    {
        audio.PlayOneShot(clip);
    }
}
