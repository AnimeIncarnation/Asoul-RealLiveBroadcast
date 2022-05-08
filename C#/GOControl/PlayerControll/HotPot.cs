using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPot : MonoBehaviour
{
    public float life = 8;
    private CharatorLife NaiLinLife;
    private CharatorLife XiangWanLife;

    void Start()
    {
        NaiLinLife = NaiLinControl.instance.gameObject.GetComponent<CharatorLife>();
        XiangWanLife = XiangWanControl.instance.gameObject.GetComponent<CharatorLife>();
    }

    void FixedUpdate()
    {
        HotPotDeath();
        Warm();
    }

    void Warm()
    {
        if (Mathf.Abs(transform.position.x - NaiLinControl.instance.transform.position.x) < 2 && Mathf.Abs(transform.position.y - NaiLinControl.instance.transform.position.y) < 3)
        {
            NaiLinLife.coldValue -= Time.deltaTime * NaiLinLife.coldVelocity * 5;
        }
        if (Mathf.Abs(transform.position.x - XiangWanControl.instance.transform.position.x) < 2 && Mathf.Abs(transform.position.y - XiangWanControl.instance.transform.position.y) < 3)
        {
            XiangWanLife.coldValue -= Time.deltaTime * XiangWanLife.coldVelocity * 5;
        }
    }

    void HotPotDeath()
    {
        life -= 0.02f;
        if (life <= 0) { Destroy(gameObject); }
    }
}
