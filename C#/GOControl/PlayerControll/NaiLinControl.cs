using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaiLinControl : MonoBehaviour
{
    public static NaiLinControl instance;
    public Rigidbody2D rd;
    public Animator anime;
    public Collider2D clider;
    public LayerMask tileMap;
    public LayerMask XiangWanLayer;
    public LayerMask platforms;
    public LayerMask MovingPlats;
    public GameObject XiangWanObject;
    public float speed;
    public float jumpCapacity;
    public bool isJump = false;
    private bool isOnPlat2 = false;
    private int fallingCal = 0;
    private GameObject collisio;
    public AudioSource audio;
    public AudioClip clip;

    public float jumpDamage = 2;
    public bool onHead = false;

    //按键控制变量：Update与FixedUpdate的通信
    public bool W = false;

    void Awake()
    {
        instance = this;
        EventCenter.Instance.AddEvent("BossLose", BossLose);
    }

    void BossLose()
    {
        transform.position = new Vector3(-220, -50, 0);
    }

    void FixedUpdate()
    {
        JumpPhysics();
        FallingIsJump();
        MovingPhysics();
        OnPlat2Physics();
    }


    // Update is called once per frame
    void Update()
    {
        MovingAnimation();
        JumpPA();
        IsOnPlat2();
    }

    void MovingPhysics()
    {
        float AD = Input.GetAxisRaw("Horizontal");
        if (AD != 0)
        {
            //rd.velocity = new Vector2(AD * speed, rd.velocity.y);
            //rd.MovePosition(new Vector2(transform.position.x + AD * speed * Time.deltaTime,transform.position.y));
            transform.position = new Vector2(transform.position.x+AD*speed*Time.deltaTime,transform.position.y);
            if (AD == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (AD < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
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

    void JumpPA()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            W = true;
           // print("GetKey.W Successed");
        }

        //落地有关判断
        if ((rd.velocity.y <= 0 && isJump)||rd.isKinematic==true)
        {
            print("进入落地判断1");
            print(clider.IsTouchingLayers(tileMap));
            if (clider.IsTouchingLayers(tileMap) ||  clider.IsTouchingLayers(MovingPlats) || clider.IsTouchingLayers(platforms) || (clider.IsTouchingLayers(XiangWanLayer)&&transform.position.y > XiangWanObject.transform.position.y+0.5))
            {
                if (clider.IsTouchingLayers(XiangWanLayer) && transform.position.y > XiangWanObject.transform.position.y + 0.5) onHead = true;
                //print(gameObject);
                //print(XiangWanObject);
                if (onHead) { DamageControl.instance.OnHeadDamage(gameObject, XiangWanObject); audio.PlayOneShot(clip); }
                print("进入落地判断2");
                anime.SetBool("IsJumping", false);
                isJump = !isJump;
                W = false;
                onHead = false;
            }
        }

    }

    void JumpPhysics()
    {
        if (W)
        {
            print("按W");
            if (!isJump)
            {
                print("按W且没跳");
                if (isOnPlat2)
                {
                    print("按W且没跳且在平台2上");
                    isOnPlat2 = false;
                    rd.isKinematic = false;
                    transform.position += new Vector3(0, 0.5f, 0);
                    jumpCapacity = 20;
                    print("在mp上跳跃");
                }
                else if(onHead)
                {
                    XiangWanObject.GetComponent<CharatorLife>().life -= jumpDamage;
                }
                print("按W所以isJump=true");
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
        if(!rd.isKinematic)
        if (!clider.IsTouchingLayers(tileMap) && !clider.IsTouchingLayers(XiangWanLayer) && !clider.IsTouchingLayers(platforms)&&!clider.IsTouchingLayers(MovingPlats))
        {
            //掉落所以isJump=true

            fallingCal++;
            if (fallingCal > 10)
            {
                print("掉落所以isJump=true");
                anime.SetBool("IsJumping", true);
                isJump = true;
                fallingCal = 0;
            }
        }
        else { fallingCal = 0; }
    }

    //本函数将乃琳碰到移动平台的对象限制在脚部
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
            if(!rd.isKinematic) rd.isKinematic = true;
            transform.position = new Vector3(transform.position.x, collisio.transform.position.y + 3.5f + (collisio.transform.localScale.x-2)*0.2f , transform.position.z);
            if (transform.position.x <= collisio.transform.position.x - 1) transform.position = new Vector3(collisio.transform.position.x - 1, transform.position.y, transform.position.z);
            else if (transform.position.x >= collisio.transform.position.x + 1) transform.position = new Vector3(collisio.transform.position.x + 1,transform.position.y, transform.position.z);
        }
        else
        {
            rd.isKinematic = false;
        }
    }

    //本碰撞函数仅用来获取乃琳碰到的石头是哪个
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
