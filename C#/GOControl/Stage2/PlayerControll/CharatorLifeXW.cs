using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharatorLifeXW : MonoBehaviour
{
    private float life;
    public float maxLife;
    private float damageCoolMax=1;
    private float damageCool;


    public Image health;
    public Collider2D bossAttack;
   
    void Start()
    {
        life = maxLife;
        damageCool = damageCoolMax;
        EventCenter.Instance.AddEvent("BossLose", BossLose);
        EventCenter.Instance.AddEvent("CharactorDamageXW", CharactorDamageXW);
    }
    void BossLose()
    {
        life = maxLife;
    }

    void FixedUpdate()
    {


        Death();
        ShowHealth();
        DamageCoolDown();
    }



    void DamageCoolDown()
    {
        if (damageCool != damageCoolMax)
        {
            damageCool -= Time.deltaTime;
            if (damageCool <= 0)
            {
                damageCool = damageCoolMax;
            }
        }

    }

    void Death()
    {
        if (life <= 0)
        {

                EventCenter.Instance.InvokeEvent("FallDeath");

        }
    }

    void ShowHealth()
    {
        health.fillAmount = life / maxLife;
        //print(health.fillAmount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Monsters")
        {
            if (col.gameObject.GetComponent<MonsterBase>().life > 0)
            {
                EventCenter.Instance.InvokeEvent("CharactorDamageXW");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col == bossAttack)
        {
            EventCenter.Instance.InvokeEvent("CharactorDamageXW");
            life -= 10;
        }
    }

    IEnumerator Blink(GameObject go, float interval = 0.08f, int times = 6)
    {
        print("进入协程");
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        for (int temp = 0; temp < times; ++temp)
        {
            print(sr.enabled);
            sr.enabled = !sr.enabled;
            print(sr.enabled);
            yield return new WaitForSeconds(interval);
        }
        go.SetActive(true);
    }

    void CharactorDamageXW()
    {
        if (damageCool == damageCoolMax)
        {
            life -= 10;
            damageCool -= Time.deltaTime;
            StartCoroutine(Blink(gameObject));
        }
    }

}
