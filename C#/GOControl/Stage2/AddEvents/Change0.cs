using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change0 : MonoBehaviour
{
    public static AudioSource audio;
    public AudioClip clip;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Players")
        { 
            EventCenter.Instance.InvokeEvent("Change0");
            
        }
    }

    void Awake()
    {
        EventCenter.Instance.AddEvent("Change0", Death);
        EventCenter.Instance.AddEvent("Change0", Music);
    }

    void Death()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void Music()
    {
        audio.PlayOneShot(clip);
    }
}
