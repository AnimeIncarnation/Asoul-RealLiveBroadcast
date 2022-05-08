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

    //�������Ʊ�����Update��FixedUpdate��ͨ��
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

        //����й��ж�
        if ((rd.velocity.y <= 0 && isJump)||rd.isKinematic==true)
        {
            print("��������ж�1");
            print(clider.IsTouchingLayers(tileMap));
            if (clider.IsTouchingLayers(tileMap) ||  clider.IsTouchingLayers(MovingPlats) || clider.IsTouchingLayers(platforms) || (clider.IsTouchingLayers(XiangWanLayer)&&transform.position.y > XiangWanObject.transform.position.y+0.5))
            {
                if (clider.IsTouchingLayers(XiangWanLayer) && transform.position.y > XiangWanObject.transform.position.y + 0.5) onHead = true;
                //print(gameObject);
                //print(XiangWanObject);
                if (onHead) { DamageControl.instance.OnHeadDamage(gameObject, XiangWanObject); audio.PlayOneShot(clip); }
                print("��������ж�2");
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
            print("��W");
            if (!isJump)
            {
                print("��W��û��");
                if (isOnPlat2)
                {
                    print("��W��û������ƽ̨2��");
                    isOnPlat2 = false;
                    rd.isKinematic = false;
                    transform.position += new Vector3(0, 0.5f, 0);
                    jumpCapacity = 20;
                    print("��mp����Ծ");
                }
                else if(onHead)
                {
                    XiangWanObject.GetComponent<CharatorLife>().life -= jumpDamage;
                }
                print("��W����isJump=true");
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
            //��������isJump=true

            fallingCal++;
            if (fallingCal > 10)
            {
                print("��������isJump=true");
                anime.SetBool("IsJumping", true);
                isJump = true;
                fallingCal = 0;
            }
        }
        else { fallingCal = 0; }
    }

    //�����������������ƶ�ƽ̨�Ķ��������ڽŲ�
    void IsOnPlat2()
    {
        if (clider.IsTouchingLayers(MovingPlats))
        {
            print("���ڴ���plat");
            isOnPlat2 = true;
        }
    }

    //��������ƶ�ƽ̨���ر��������λ���ƶ�
    void OnPlat2Physics()
    {
        if (isOnPlat2)
        {
            print("��MP�ϣ�������ʧ");
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

    //����ײ������������ȡ����������ʯͷ���ĸ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlats")
        {
            print("��MP�ϣ�����λ��");
            collisio = collision.gameObject;
        }
    }

    //����ֻ������Ծ�뿪ƽ̨

}
