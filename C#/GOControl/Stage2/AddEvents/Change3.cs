using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change3 : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossTile;
    public GameObject foods;
    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Players")
        {
            EventCenter.Instance.InvokeEvent("Change3");
            audio.Play();
        }
    }

    void Awake()
    {
        EventCenter.Instance.AddEvent("Change3", Death);
    }

    void Death()
    {
        boss.GetComponent<MonsterBoss>().enterStage2 = true;
        bossTile.SetActive(true);
        foods.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
