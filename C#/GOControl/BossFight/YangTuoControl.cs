using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YangTuoControl : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    Animator anim;
    GameObject hotPot;
    public Image blood;

    State s = State.stand;
    float life = 100;


    float standTime = 1;
    float walkTime = 2;
    float skillTime = 0.94f;
    float standTimeRemain ;
    float walkTimeRemain ;
    float skillTimeRemain ;

    int moveState = 1;
    float fireCD = 1;
    float attackCD = 2;
    float fireCDRemain;
    float attackCDRemain;

    enum State
    { 
        stand,
        walk,
        skill  
    }

    void Start()
    {
        audio.clip = clip;
        anim = GetComponent<Animator>();
        standTimeRemain = standTime;
        walkTimeRemain = walkTime;
        skillTimeRemain = skillTime;
        
        fireCDRemain = fireCD;
        attackCDRemain = attackCD;

        EventCenter.Instance.AddEvent("BossLose", BossLose);
        StartCoroutine(FireSearch());
    }

    void BossLose()
    {
        life = 100;
    }

    void FixedUpdate()
    {
        Death();
        Act();
        FireAttack();
        ShowBlood();
    }
    void ShowBlood()
    {
        blood.fillAmount = life / 100;
    }


    //伤害系统
    void Death()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false);
            EventCenter.Instance.InvokeEvent("Win");
        }
    }

    void OnTriggerEnter2D(Collider2D XW)
    {
        if (XW.gameObject.name == "向晚")
        {
            if(XW.gameObject.GetComponent<Rigidbody2D>().velocity.y >= -20)
            {
                life -= Mathf.Abs(XW.gameObject.GetComponent<Rigidbody2D>().velocity.y / 20);
                audio.PlayOneShot(clip);
            }
            else if (XW.gameObject.GetComponent<Rigidbody2D>().velocity.y >= -35)
            {
                life -= Mathf.Abs(XW.gameObject.GetComponent<Rigidbody2D>().velocity.y/10);
                audio.PlayOneShot(clip);
            }
            else if (XW.gameObject.GetComponent<Rigidbody2D>().velocity.y <= -35)
            {
                life -= Mathf.Abs(XW.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                audio.PlayOneShot(clip);
            }
            StartCoroutine(Blink(this.gameObject, 0.08f, 6));
            print(life);
            print(XW.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void FireAttack()
    {
        if (hotPot != null)
        {
            print("羊驼找到了火锅");
            print(fireCDRemain);
            print(fireCD);
            if(hotPot.transform.position.x<=-259.9&& hotPot.transform.position.x >= -260.9)
            if (fireCDRemain == fireCD)
            {
                print("羊驼火锅不在cd");
                if (Mathf.Abs(transform.position.x - hotPot.transform.position.x) <= 1.5)
                {
                    life -= 2;
                    fireCDRemain -= Time.deltaTime;
                    StartCoroutine(Blink(this.gameObject, 0.08f, 6));
                    print(life);
                }
            }
        }
        if (fireCD != fireCDRemain)
        {
            fireCDRemain -= Time.deltaTime;
            if (fireCDRemain <= 0)
            {
                fireCDRemain = fireCD;
            }
        }
    }

    IEnumerator FireSearch()
    {
        while (true)
        {
            hotPot = GameObject.Find("HotPot(Clone)");
            yield return new WaitForSeconds(1);

        }
        
    }

    IEnumerator Blink(GameObject go, float interval, int times)
    {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        for (int temp = 0; temp < times; ++temp)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(interval);
        }
        go.SetActive(true);
    }




    //动画系统
    void Act()
    {
        if (s == State.stand)
        {
            StandAct();
        }
        else if (s == State.walk)
        {
            WalkAct();
        }
        else if(s == State.skill)
        {
            SkillAct();
        }
        StateSwitch();
    }

    void StateSwitch()
    {
        if (s == State.stand)
        {
            standTimeRemain -= Time.deltaTime;
            if (standTimeRemain <= 0)
            {
                s = State.walk;
                standTimeRemain = standTime;
            }
        }
        else if (s == State.walk)
        {
            walkTimeRemain -= Time.deltaTime;
            if (walkTimeRemain <= 0)
            {
                s = State.skill;
                walkTimeRemain = walkTime;
            }
        }
        else if (s == State.skill)
        {
            skillTimeRemain -= Time.deltaTime;
            if (skillTimeRemain <= 0)
            {
                s = State.walk;
                skillTimeRemain = skillTime;
            }
        }
    }

    void StandAct()
    {
        anim.SetInteger("state", 0);
    }
    void SkillAct()
    {
        anim.SetInteger("state", 2);
    }
    void WalkAct()
    {
        
        anim.SetInteger("state", 1);

        if (moveState == 1) Right();
        else Left();

        if (transform.position.x <= -264)
        {
            moveState = 1;
        }
        else if(transform.position.x >= -250)
        {
            moveState = 0;
        }
    }
    void Right()
    {
        transform.position += new Vector3(0.1f, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }
    void Left()
    {
        transform.position -= new Vector3(0.1f, 0, 0);
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
