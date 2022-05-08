using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangWanSkill : MonoBehaviour
{
    //�㶨������
    public  float       speed = 1;
    public  float       gasTime = 3;
    public  float       gasTime2 = 5;
    public  float       coolingTime = 5;
    private Rigidbody2D rd;
    private Animator anim;
    private AudioSource audio;
    public AudioClip clip;

    //�ж���
    private bool       pressU        = false;
    private bool       enterCoolDown = false; //��enterCoolDown�������������Ƿ�����ȴ��ͬʱ�����Ƿ���ʹ�ü��ܵ�״̬���߼��ж�
    private bool       notPlayMusic  = true;
    private bool       gasRunOut     = false;
    private GameObject hotPot;
   

    //���Ʊ���
    private float coolingCountDown ;
    private float flyingCount = 0;
    private float gasChoice ;

    void Awake()
    {
        Init();
    }
    void Start()
    {
        //�޸�����������еļ���ѡ��
        XiangWanControl.instance.haveSkill = true;
        
        //��ʼ������
        rd = XiangWanControl.instance.gameObject.GetComponent<Rigidbody2D>();
        coolingCountDown = coolingTime;
        gasChoice = gasTime;
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //������ܲ�����ȴ��
        if (!enterCoolDown)
        {
            print("���ܲ�����ȴ");
            //�ж��Ƿ�ʹ�ü��ܣ�����U����
            if (pressU)
            {
                print("����");

                //��������
                if(notPlayMusic)
                {
                    audio.PlayOneShot(clip);
                    notPlayMusic = false;
                }
                    

                //���ö���
                anim.SetBool("IsFlying", true);

                //����
                rd.velocity += (new Vector2(0, speed));
                print(rd.velocity);

                //��������ʱ�䣬���޶�ʱ���G
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

        //�����������ȴ��
        else
        {
            //�����ص�ԭ��״̬

            //������ȴ�߼�
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
        //print("���");
        //����Ӱ���U����Ϊ�ſ�U��������gasʹ������,�Ҵ�ʱ���ܲ�������ȴ��
        if (((Input.GetKeyUp(KeyCode.U) && pressU == true)||gasRunOut) && enterCoolDown == false)
        {
            //���ܽ�����ȴ
            print("���ܽ�����ȴ");
            enterCoolDown = true;
            flyingCount = 0;
            anim.SetBool("IsFlying", false);
            notPlayMusic = true;
        }

        //����տ�ʼ����U�����Ҽ��ܲ�����ȴ��
        if (Input.GetKey(KeyCode.U) && pressU == false && enterCoolDown == false)
        {
            //�ж�gasѡ��
            gasChoice = GetGasChoice();
        }

        if (Input.GetKey(KeyCode.U))
        {
            //����U��
            pressU = true;
            print("����U��");
        }
        else
        {
            //�ɿ�U��
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
