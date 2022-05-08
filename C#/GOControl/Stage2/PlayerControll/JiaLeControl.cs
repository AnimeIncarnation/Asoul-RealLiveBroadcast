using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiaLeControl : MonoBehaviour
{
    public static JiaLeControl instance;
    public Rigidbody2D rd;
    public Animator anime;
    public Collider2D clider;
    public LayerMask lyer;
    public LayerMask XiangWanLayer;
    public LayerMask platforms;
    public LayerMask monsters;
    public GameObject XiangWanObject;
    public Rigidbody2D rdXiangWan;
    public float speed = 5;
    private float jumpCapacity = 14;
    public bool isJump = false;
    //private bool onHead = false;
    private int fallingCal = 0;
    public bool haveSkill = false;
    private GameObject collisio;
    public AudioSource audio;
    public AudioClip swordclip;
    //public float jumpDamage = 2;

    private bool W = false;
    public bool swordsGet = false;
    public float swordLife;
    public Collider2D swordCollider;
    private bool attack = false;

    //boss关卡

    // public Collider2D BossCollider;
    //  public GameObject bossGameObject;


    //void BossCollision()
    //{
    //    if (BossCollider.IsTouchingLayers(NaiLinLayer))
    //    {
    //        DamageControl.instance.OnHeadDamage(bossGameObject, gameObject);
    //    }
    //}

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
        JumpPhysics();
        FallingIsJump();
        MovingPhysics();
        //BossCollision();
        Attack();
    }

    void Update()
    {
        MovingAnimation();
        JumpGetAndAnimation();
        HaveSwordsAnimation();
        AttackGet();
        QuitSword();
        SwordDie();
    }

    void HaveSwordsAnimation()
    {
        if (swordsGet)
        {
            anime.SetBool("HaveSwords", true);
            swordCollider.enabled = true;
        }
        else
        {
            anime.SetBool("HaveSwords", false);
            swordCollider.enabled = false;
        }
    }


    void MovingPhysics()
    {
        bool a = Input.GetKey(KeyCode.A);
        bool d = Input.GetKey(KeyCode.D);
        if (a != false || d !=false)
        {
            if (d == true)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rd.velocity = new Vector2(speed, rd.velocity.y);
            }
            if (a == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rd.velocity = new Vector2(-speed, rd.velocity.y);
            }
        }
        else { rd.velocity = new Vector2(0, rd.velocity.y); }
    }

    void MovingAnimation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anime.SetInteger("MovingMode", 1);
        }
        else { anime.SetInteger("MovingMode", 0); }

    }

    void JumpGetAndAnimation()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            W = true;
        }
        
        if ((rd.velocity.y <= 0 && isJump) )
        {
            if (clider.IsTouchingLayers(monsters) || clider.IsTouchingLayers(lyer) || clider.IsTouchingLayers(platforms) || (clider.IsTouchingLayers(XiangWanLayer) && transform.position.y > XiangWanObject.transform.position.y + 0.5))
            {
                //if (clider.IsTouchingLayers(NaiLinLayer) && transform.position.y > NaiLinObject.transform.position.y + 0.5) onHead = true;
                //if (onHead) { DamageControl.instance.OnHeadDamage(gameObject, NaiLinObject); }
                anime.SetBool("IsJumping", false);
                isJump = !isJump;
                //print(isJump);
                W = false;  //在落地的一瞬间让I为false，防止落地一瞬间因为速度归零而导致进入了FixedUpdate中的函数
                //onHead = false;
                //
                speed = 5;
            }
        }
    }
    
    void JumpPhysics()
    {
        if (W)
        {
            print("按了W");
            if (!isJump)
            {
                //if (onHead)
                //{
                //    NaiLinObject.GetComponent<CharatorLife>().life -= 2;
                //}
                print("按I所以isJump=true");
                W = false;
                isJump = true;
                rd.velocity = new Vector2(rd.velocity.x, jumpCapacity);
                jumpCapacity = 14;
                anime.SetBool("IsJumping", true);
            }
        }
    }

    void FallingIsJump()
    {
        if (!clider.IsTouchingLayers(lyer) && !clider.IsTouchingLayers(XiangWanLayer) && !clider.IsTouchingLayers(platforms))
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


    void AttackGet()
    {
        if (swordsGet)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                attack = true;

            }
        }
    }

    void Attack()
    {
        if (attack)
        {
            audio.PlayOneShot(swordclip);
            anime.SetTrigger("Attack");
            attack = false;
        }
    }

    void QuitSword()
    {
        if (swordsGet)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                swordsGet = false;
                GameObject s = GameObject.Instantiate(Resources.Load<GameObject>("Prefebs/剑"), transform.position + new Vector3(0, 5, 0), transform.rotation);
                s.GetComponent<Swords>().life = swordLife;
            }
        }
    }

    void SwordDie()
    {
        if (swordLife <= 0)
        {
            swordsGet = false;
        }
    }

}
