using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangWanSkill : MonoBehaviour
{
    //恒定不变项
    public  float       speed = 1;
    public  float       gasTime = 3;
    public  float       gasTime2 = 5;
    public  float       coolingTime = 5;
    private Rigidbody2D rd;
    private Animator anim;
    private AudioSource audio;
    public AudioClip clip;

    //判定项
    private bool       pressU        = false;
    private bool       enterCoolDown = false; //用enterCoolDown变量来处理技能是否在冷却，同时处理是否处于使用技能的状态的逻辑判断
    private bool       notPlayMusic  = true;
    private bool       gasRunOut     = false;
    private GameObject hotPot;
   

    //控制变量
    private float coolingCountDown ;
    private float flyingCount = 0;
    private float gasChoice ;

    void Awake()
    {
        Init();
    }
    void Start()
    {
        //修改向晚控制器中的技能选项
        XiangWanControl.instance.haveSkill = true;
        
        //初始化变量
        rd = XiangWanControl.instance.gameObject.GetComponent<Rigidbody2D>();
        coolingCountDown = coolingTime;
        gasChoice = gasTime;
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //如果技能不在冷却中
        if (!enterCoolDown)
        {
            print("技能不在冷却");
            //判断是否使用技能（按下U键）
            if (pressU)
            {
                print("给力");

                //设置音乐
                if(notPlayMusic)
                {
                    audio.PlayOneShot(clip);
                    notPlayMusic = false;
                }
                    

                //设置动画
                anim.SetBool("IsFlying", true);

                //上升
                rd.velocity += (new Vector2(0, speed));
                print(rd.velocity);

                //计算上升时间，到限定时间就G
                flyingCount += Time.deltaTime;
                print(flyingCount);
                if (flyingCount >= gasChoice)
                {
                    enterCoolDown = true;
                    flyingCount = 0;
                    anim.SetBool("IsFlying", false);
                    notPlayMusic = true;
                }
            }
        }

        //如果技能在冷却中
        else
        {
            //动画回到原本状态

            //技能冷却逻辑
            if (coolingCountDown <= 0) 
            { 
                enterCoolDown = false; 
                coolingCountDown = coolingTime; 
            }
            coolingCountDown -= Time.deltaTime;
        }
        
    }
    void Update()
    {
        //print("你好");
        //如果从按下U键变为放开U键，或者gas使用完了,且此时技能并不在冷却中
        if (((Input.GetKeyUp(KeyCode.U) && pressU == true)||gasRunOut) && enterCoolDown == false)
        {
            //技能进入冷却
            print("技能进入冷却");
            enterCoolDown = true;
            flyingCount = 0;
            anim.SetBool("IsFlying", false);
            notPlayMusic = true;
        }

        //如果刚开始按下U键，且技能不在冷却中
        if (Input.GetKey(KeyCode.U) && pressU == false && enterCoolDown == false)
        {
            //判断gas选择
            gasChoice = GetGasChoice();
        }

        if (Input.GetKey(KeyCode.U))
        {
            //按下U键
            pressU = true;
            print("按下U键");
        }
        else
        {
            //松开U键
            pressU = false;
        }

    }

    void Init()
    {
        EventCenter.Instance.AddEvent("XiangWanSkillGet",Revive);
        this.enabled = false;
    }
    void Revive()
    {
        this.enabled = true;
    }
    float  GetGasChoice()
    {
        if ((hotPot = GameObject.Find("HotPot(Clone)")) != null)
        {
            if (Mathf.Abs(transform.position.x - hotPot.transform.position.x) < 1.5 && transform.position.y - hotPot.transform.position.y > 0)
            {
                XiangWanControl.instance.speed = 15;
                return gasTime2;
            }
        }
        return gasTime;
    }
}
