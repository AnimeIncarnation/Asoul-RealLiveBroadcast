using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public bool isLeft = true;
    private float speed = 0.075f;
    private float scale;
    private bool canMove = true;


    void FixedUpdate()
    {
        if (canMove)
        {
            if (isLeft)
            {
                Left();
            }
            else
            {
                Right();
            }
        }
        TestCanMove();
    }

    void TestCanMove()
    {
        if (canMove)
        {
            if (gameObject.GetComponent<MonsterBase>().life <= 0)
            {
                canMove = false;
            }
        }
    }

    void Start()
    {
        scale = transform.localScale.x;
    }

    void Left()
    {
        transform.position += new Vector3(-speed,0,0);
        transform.localScale = new Vector3(scale,scale,1);
    }

    void Right()
    {
        transform.position += new Vector3(speed, 0, 0);
        transform.localScale = new Vector3(-scale, scale, 1);
    }






    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "MonsterMove")
        {
            if (isLeft)
            {
                isLeft = false;
            }
            else
            {
                isLeft = true;
            }
        }
        
    }
}
