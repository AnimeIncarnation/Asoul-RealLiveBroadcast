using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change1 : MonoBehaviour
{
    public AudioSource audio;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Players")
        {
            audio.Play();
            EventCenter.Instance.InvokeEvent("Change1");
        }
    }

    void Awake()
    {
        EventCenter.Instance.AddEvent("Change1", Death);
    }

    void Death()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
