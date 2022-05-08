using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangWanControl2 : MonoBehaviour
{
    public static XiangWanControl2 instance;
    public Rigidbody2D rd;
    public Animator anime;
    public Collider2D clider;
    public LayerMask lyer;
    public LayerMask NaiLinLayer;
    public LayerMask platforms;
    public LayerMask monsters;
    public GameObject NaiLinObject;
    public Rigidbody2D rdNaiLin;
    public float speed = 5;
    private float jumpCapacity =14;
    public bool isJump = false;
    //private bool onHead = false;
    private int fallingCal = 0;
    public bool haveSkill = false;
    private GameObject collisio;
    public AudioSource audio;
    public AudioClip swordclip;
    public AudioClip bagclip;
    //public float jumpDamage = 2;

    private bool I = false;
    public bool swordsGet = false;
    private bool attack = false;
    public Collider2D swordCollider;
    public  float swordLife;
    private bool isFlying = false;


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
        Attack();
        //BossCollision();
        CanFlyPhysics();
    }

    void Update()
    {
        MovingAnimation();
        JumpGetAndAnimation();
        HaveSwordsAnimation();
        AttackGet();
        QuitSword();
        SwordDie();
        CanFlyGetAndAnime();
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
        bool j = Input.GetKey(KeyCode.J);
        bool l = Input.GetKey(KeyCode.L);
        if (j != false || l !=false)
        {
            if (j == true)
            {
                transform.localScale = new Vector3(-0.88f, 0.88f, 1);
                rd.velocity = new Vector2(-speed, rd.velocity.y);
            }
            if (l == true)
            {
                transform.localScale = new Vector3(0.88f, 0.88f, 1);
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

    void JumpGetAndAnimation()
    {
        if(!swordsGet)
        if (Input.GetKeyDown(KeyCode.I))
        {
            I = true;
        }
        
        if ((rd.velocity.y <= 0 && isJump) )
        {
            if (clider.IsTouchingLayers(monsters) || clider.IsTouchingLayers(lyer) || clider.IsTouchingLayers(platforms) || (clider.IsTouchingLayers(NaiLinLayer) && transform.position.y > NaiLinObject.transform.position.y + 0.5))
            {
                //if (clider.IsTouchingLayers(NaiLinLayer) && transform.position.y > NaiLinObject.transform.position.y + 0.5) onHead = true;
                //if (onHead) { DamageControl.instance.OnHeadDamage(gameObject, NaiLinObject); }
                anime.SetBool("IsJumping", false);
                anime.SetBool("IsFlying", false);
                isJump = !isJump;
                isFlying = false;
                //print(isJump);
                I = false;  //在落地的一瞬间让I为false，防止落地一瞬间因为速度归零而导致进入了FixedUpdate中的函数
                //onHead = false;
                //
                speed = 5;
            }
        }
    }
    
    void JumpPhysics()
    {
        if (I)
        {
            print("按了I");
            if (!isJump)
            {
                //if (onHead)
                //{
                //    NaiLinObject.GetComponent<CharatorLife>().life -= 2;
                //}
                print("按I所以isJump=true");
                I = false;
                isJump = true;
                rd.velocity = new Vector2(rd.velocity.x, jumpCapacity);
                jumpCapacity = 14;
                anime.SetBool("IsJumping", true);
            }
        }
    }

    void FallingIsJump()
    {
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

    void AttackGet()
    {
        if (swordsGet)
        {
            if (Input.GetKeyDown(KeyCode.H))
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
            if (Input.GetKeyDown(KeyCode.B))
            {
                swordsGet = false;
                GameObject s = GameObject.Instantiate(Resources.Load<GameObject>("Prefebs/剑"), transform.position + new Vector3(0,5,0), transform.rotation);
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


    void CanFlyGetAndAnime()
    {
        if (isJump)
        {
            if (rd.velocity.y < 0)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    audio.PlayOneShot(bagclip);
                    isFlying = !isFlying;
                    if (isFlying)
                    {
                        anime.SetBool("IsFlying", true);
                    }
                    else
                    {
                        anime.SetBool("IsFlying", false);
                    }
                }
            }
        }
    }

    void CanFlyPhysics()
    {
        if (isFlying)
        {
            rd.velocity = new Vector2(rd.velocity.x, -1);
        }
    }
}
