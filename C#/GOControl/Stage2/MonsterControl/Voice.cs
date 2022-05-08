using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;


    void Start()
    {
        EventCenter.Instance.AddEvent("Boommm",bom);
    }

    void bom()
    {
        audio.PlayOneShot(clip);
    }
}
