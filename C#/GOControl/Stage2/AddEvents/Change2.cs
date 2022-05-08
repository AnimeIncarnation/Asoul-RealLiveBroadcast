using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change2 : MonoBehaviour
{
    public AudioSource audio;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Players")
        {
            EventCenter.Instance.InvokeEvent("Change2");
            audio.Play();
        }
    }

    void Awake()
    {
        EventCenter.Instance.AddEvent("Change2", Death);
        EventCenter.Instance.AddEvent("Change2", MoveXW);
    }

    void Death()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void MoveXW()
    {
        XiangWanControl2.instance.gameObject.transform.position = JiaLeControl.instance.gameObject.transform.position;
    }

}
