using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharatorLife : MonoBehaviour
{
    public float life;
    public float maxLife;

    public float coldValue = 0;
    public float maxColdValue = 100;
    public float coldVelocity = 3;

    public Image health;
    public Image cold;
   
    void Start()
    {
        life = maxLife;
        EventCenter.Instance.AddEvent("BossLose", BossLose);
    }
    void BossLose()
    {
        life = maxLife;
    }

    void FixedUpdate()
    {
        ColdUp();
        LifeDown_Cold();
        Death();
        ShowHealth();
        ShowCold();
    }

    void ColdUp()
    {
        if (transform.position.x >= -220)
        {
            if (coldValue < 100)
            {
                coldValue += Time.deltaTime * coldVelocity;
            }
        }
        else
        {
            if (coldValue > 0)
            {
                coldValue -= Time.deltaTime * 3;
            }
        }
        if (coldValue <= 0)
        {
            coldValue = 0;
        }
    }

    void LifeDown_Cold()
    {
        if(coldValue>=100)
        {
            coldValue = 100;
            life -= Time.deltaTime;
        }
    }

    void Death()
    {
        if (life <= 0)
        {
            life = 0;
            if(NaiLinControl.instance.gameObject.transform.position.x<-220 && XiangWanControl.instance.gameObject.transform.position.x<-220)
            {
                EventCenter.Instance.InvokeEvent("BossLose");
            }
            else
            {
                TryTimes.tryTimes++;
                EventCenter.Instance.InvokeEvent("Lose");
            }
            
        }
    }

    void ShowHealth()
    {
        health.fillAmount = life / maxLife;
        //print(health.fillAmount);
    }

    void ShowCold()
    {
        cold.fillAmount = coldValue / maxColdValue;
        //print(coldValue);
        //print(maxColdValue);
        //print(cold.fillAmount);
    }
}
