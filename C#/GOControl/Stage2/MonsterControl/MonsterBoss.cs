using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBoss : MonsterBase
{
    private float maxLife;
    public bool isYun = false;
    public bool enterStage2 = false;
    private bool stage2Generation = false;
    public Image blood;
    public GameObject danMu;

    private float ballCoolDownMax = 1;
    private float ballCoolDown;
    private float attack1CoolDownMax = 1;
    private float attack1CoolDown;
    private bool attack1Able = true;
    private int  attack1Times = 0;
    private float attack2CoolDownMax = 1;
    private float attack2CoolDown;
    private float jiaLePosX;
    public float speed = 1;

    void Awake()
    {
        ballCoolDown = ballCoolDownMax;
        attack1CoolDown = attack1CoolDownMax;
        attack2CoolDown = attack2CoolDownMax;
        maxLife = life;
        EventCenter.Instance.AddEvent("BossFightTrigger",Emerge);
        EventCenter.Instance.AddEvent("Win!", Death);
        gameObject.SetActive(false);
    }

    void Emerge()
    {
        gameObject.SetActive(true);
    }

    void Update() { }

    void FixedUpdate()
    {
        //�����ж�
        if (life <= 0)
        {
            EventCenter.Instance.InvokeEvent("Win!");
        }
        //չʾѪ��
        blood.fillAmount = life / maxLife;

        jiaLePosX = JiaLeControl.instance.gameObject.transform.position.x;
        if (!enterStage2)
        {
            //ϣ���ھ���Ϊ20ʱ2��CD������Ϊ1ʱ0.75��CD
            ballCoolDownMax = Mathf.Abs(jiaLePosX - transform.position.x)*0.0778f+0.111f;
            if (ballCoolDown > 0)
            {
                ballCoolDown -= Time.deltaTime;
            }
            else
            {
                //��������ʱ�ᴥ�����ɵ�Ļ���¼�
                anim.SetTrigger("UseSkill2");
                ballCoolDown = ballCoolDownMax;
            }
        }
        else
        {
            if (!stage2Generation)
            {
                anim.SetBool("Stage1",false);
                EventCenter.Instance.InvokeEvent("Stage2");
                stage2Generation = true;
            }
            else//���׶��߼�����
            {
                //�����߼�
                if (attack1Able)
                {
                    if (attack1CoolDown > 0)
                    {
                        attack1CoolDown -= Time.deltaTime;
                    }
                    else
                    {
                        anim.SetTrigger("Attack1");
                        attack1CoolDown = attack1CoolDownMax;
                        ++attack1Times;
                        if (attack1Times == 2)
                        {
                            attack1Able = false;
                            attack1Times = 0;
                        }
                    }
                }
                else
                {
                    if (attack2CoolDown > 0)
                    {
                        attack2CoolDown -= Time.deltaTime;
                    }
                    else
                    {
                        anim.SetTrigger("Attack2");
                        attack2CoolDown = attack2CoolDownMax;
                        attack1Able = true;
                    }
                }

                //�����߼�
                if (!isYun)
                {
                    if (jiaLePosX < transform.position.x && transform.position.x > 595.8f)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        MoveLeft();
                    }
                    else if (jiaLePosX > transform.position.x && transform.position.x < 608.5f)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        MoveRight();
                    }
                }
            }
        }
    }

    void MoveLeft()
    {
        transform.position -= new Vector3(Time.deltaTime * speed,0,0);
    }
    void MoveRight()
    {
        transform.position += new Vector3(Time.deltaTime * speed,0,0);
    }

    void DanMuGeneration()
    {
        GameObject obj = GameObject.Instantiate(danMu, transform.position, transform.rotation);
        obj.GetComponent<DanMu>().JiaLeSword = swordColJL;
        obj.GetComponent<DanMu>().XiangWanSword = swordColXW;
    }

    override
    protected void Death()
    {
        print("death");
        Destroy(gameObject);
    }
}
