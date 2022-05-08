using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_6 : MonoBehaviour
{
    public int speed;
    private bool state = false;
    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
        print(initPosition);
    }


    void FixedUpdate()
    {
        //print(transform.position.y);
        if (transform.position.y >= -25)
        {
            Down();
        }
        else if(transform.position.y <= -35)
        {
            Up();
        }
        Move();
    }

    void Down()
    {
        state = true;
    }

    void Up()
    {
        state = false;
    }

    void Move()
    {
        //����
        if (!state)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        //�½�
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        
    }
}
