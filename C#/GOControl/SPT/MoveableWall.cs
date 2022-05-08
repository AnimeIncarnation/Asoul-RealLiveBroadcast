using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWall : MonoBehaviour
{
    private int num = 0;
    private Rigidbody2D rd;

    public float down_1 = -3;
    public float down_2 = -6;
    public float speed = 1;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "œÚÕÌ2"|| col.gameObject.name == "ÁÏ¿÷")
        {
            num++;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "œÚÕÌ2" || col.gameObject.name == "ÁÏ¿÷")
        {
            num--;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //print(num);
        if (num == 0)
        {
            Pos1();
        }
        else if (num == 1)
        {
            Pos2();
        }
        else if (num == 2)
        {
            Pos3();
        }
        //print(transform.localPosition);
    }


    void Pos1()
    {
        if (transform.localPosition.y < 0)
        {
            Up();
        }
        else
        {
            Down();
        }
    }

    void Pos2()
    {
        if (transform.localPosition.y > down_1)
        {
            Down();
        }
        else if (transform.localPosition.y < down_1)
        {
            Up();
        }
    }

    void Pos3()
    {
        if (transform.localPosition.y > down_2)
        {
            Down();
        }
        else
        {
            Up();
        }
    }


    void Down()
    {
        rd.velocity = new Vector2(0, -speed);
    }

    void Up()
    {
        rd.velocity = new Vector2(0, speed);
    }
}
