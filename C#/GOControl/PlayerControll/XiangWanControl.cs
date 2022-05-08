using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangWanControl : MonoBehaviour
{
    public static XiangWanControl instance;
    public Rigidbody2D rd;
    public Animator anime;
    public Collider2D clider;
    public LayerMask lyer;
    public LayerMask NaiLinLayer;
    public LayerMask platforms;
    public LayerMask MovingPlats;
    public GameObject NaiLinObject;
    public Rigidbody2D rdNaiLin;
    public float speed;
    public float jumpCapacity;
    public bool isJump = false;
    private bool onHead = false;
    private int fallingCal = 0;
    private bool isOnPlat2 = false;
    public bool haveSkill = false;
    private GameObject collisio;
    public AudioSource audio;
    public AudioClip clip;

    public float jumpDamage = 2;

    public bool I = false;

    public Collider2D BossCollider;
    public GameObject bossGameObject;


    void BossCollision()
    {
        if (BossCollider.IsTouchingLayers(NaiLinLayer))
        {
            DamageControl.instance.OnHeadDamage(bossGameObject, gameObject);
        }
    }

    void Awake()
    {
        instance = this;
        EventCenter.Instance.AddEvent("BossLose", BossLose);
    }
    void BossLose()
    {
        transform.position =new Vector3( -220,-18,0);
    }

    void FixedUpdate()
    {
        if (I)
        {
            if (!isJump)
            {
                if (isOnPlat2)
                {
                    print("按W且没跳且在平台2上");
                    isOnPlat2 = false;
                    rd.isKinematic = false;
                    transform.position += new Vector3(0, 0.5f, 0);
                    jumpCapacity = 20;
                    print("在mp上跳跃");
                }
                else if (onHead)
                {
                    NaiLinObject.GetComponent<CharatorLife>().life -= 2;
                }
                print("按W所以isJump=true");
                I = false;
                isJump = true;
                rd.velocity = new Vector2(rd.velocity.x, jumpCapacity); 
                jumpCapacity = 14;
                anime.SetBool("IsJumping", true);
            }
        }
        //HeadMove();
        FallingIsJump();
        MovingPhysics();
        OnPlat2Physics();
        BossCollision();
    }

    // Update is called once per frame
    void Update()
    {
        MovingAnimation();
        JumpPA();
        IsOnPlat2();
        // HeadJudge();
    }

    void MovingPhysics()
    {
        bool j = Input.GetKey(KeyCode.J);
        bool l = Input.GetKey(KeyCode.L);
        if (j != false || l !=false)
        {
            if (j == true)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rd.velocity = new Vector2(-speed, rd.velocity.y);
            }
            if (l == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rd.velocity = new Vector2(speed, rd.velocity.y);
            }
        }
        else { rd.velocity = new Vector2(0, rd.velocity.y); }
    }

    void MovingAnimation()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
        {
            anime.SetInteger("MovingMode", 1);
        }
        else { anime.SetInteger("MovingMode", 0); }

    }

    void JumpPA()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            I = true;
        }
        
        if ((rd.velocity.y <= 0 && isJump) || rd.isKinematic == true)
        {
            print("进入落地判断1");
            print(clider.IsTouchingLayers(MovingPlats));
            if (clider.IsTouchingLayers(MovingPlats) || clider.IsTouchingLayers(lyer) || clider.IsTouchingLayers(platforms) || (clider.IsTouchingLayers(NaiLinLayer) && transform.position.y > NaiLinObject.transform.position.y + 0.5))
            {
                if (clider.IsTouchingLayers(NaiLinLayer) && transform.position.y > NaiLinObject.transform.position.y + 0.5) onHead = true;
                if (onHead) { DamageControl.instance.OnHeadDamage(gameObject, NaiLinObject);audio.PlayOneShot(clip); }
                print("进入落地判断2");
                anime.SetBool("IsJumping", false);
                isJump = !isJump;
                //print(isJump);
                I = false;  //在落地的一瞬间让I为false，防止落地一瞬间因为速度归零而导致进入了FixedUpdate中的函数
                onHead = false;
                //
                speed = 5;
            }
        }
    }

    void FallingIsJump()
    {
        if(!rd.isKinematic)
        if (!clider.IsTouchingLayers(lyer) && !clider.IsTouchingLayers(NaiLinLayer) && !clider.IsTouchingLayers(platforms))
        {
            fallingCal++;
            if(fallingCal>10)
            {
                anime.SetBool("IsJumping", true);
                isJump = true;
                fallingCal = 0;
            }
        }
        else { fallingCal = 0; }
    }

    //本函数将向晚碰到移动平台的对象限制在脚部
    void IsOnPlat2()
    {
        if (clider.IsTouchingLayers(MovingPlats))
        {
            print("脚在触碰plat");
            isOnPlat2 = true;
        }
    }

    //如果碰到移动平台，关闭物理，相对位置移动
    void OnPlat2Physics()
    {
        if (isOnPlat2)
        {
            print("在MP上，物理消失");
            if (!rd.isKinematic) rd.isKinematic = true;
            transform.position = new Vector3(transform.position.x, collisio.transform.position.y + 3.5f + (collisio.transform.localScale.x - 2) * 0.2f, transform.position.z);
            if (transform.position.x <= collisio.transform.position.x - 1) transform.position = new Vector3(collisio.transform.position.x - 1, transform.position.y, transform.position.z);
            else if (transform.position.x >= collisio.transform.position.x + 1) transform.position = new Vector3(collisio.transform.position.x + 1, transform.position.y, transform.position.z);
        }
        else
        {
            rd.isKinematic = false;
        }
    }

    //本碰撞函数仅用来获取向晚碰到的石头是哪个
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlats")
        {
            print("在MP上，产生位移");
            collisio = collision.gameObject;
        }
    }

    //限制只能用跳跃离开平台
}
