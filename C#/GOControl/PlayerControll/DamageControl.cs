using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl:MonoBehaviour
{
    public static DamageControl instance;

    private float interval = 0.08f;
    private int times = 6;

    private int headCool = 0;
    private bool headUsed = false;


    private void StartBlink(GameObject go)
    {
        StartCoroutine(Blink(go,interval,times));
    }

    public void OnHeadDamage(GameObject gong,GameObject shou)
    {
        if (!headUsed)
        {
            shou.GetComponent<CharatorLife>().life -= 1;
            shou.GetComponent<Rigidbody2D>().AddForce(gong.GetComponent<Rigidbody2D>().velocity * 10);
            StartBlink(shou);
            headUsed = true;
        }
    }

    IEnumerator Blink(GameObject go,float interval,int times)
    {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        for (int temp = 0; temp < times; ++temp)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(interval);
        }
        go.SetActive(true);
    }

    void Start()
    {
        instance = this;
    }
    
    void FixedUpdate()
    {
        if (headUsed)
        {
            headCool += 1;
            if (headCool == 50) { headCool = 0;headUsed = false; }
        }
    }

}
