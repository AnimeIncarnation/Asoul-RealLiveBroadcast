using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanMu : MonoBehaviour
{
    public Collider2D JiaLeSword;
    public Collider2D XiangWanSword;

    public float speed = 1;
    private int life = 2;
    private float time = 18;

    void FixedUpdate()
    {
        //λ���߼�
        transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);

        //�����߼�
        if (life == 1)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        else if (life <= 0)
        {
            Destroy(gameObject);
        }


        //time�߼�
        if (time <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col == JiaLeSword || col == XiangWanSword)
        {
            --life;
        }
        else if (col.gameObject.tag == "TileMap")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Players")
        {
            if (col.gameObject.name == "����2")
            {
                EventCenter.Instance.InvokeEvent("CharactorDamageXW");
            }
            else if(col.gameObject.name == "����")
            {
                EventCenter.Instance.InvokeEvent("CharactorDamageJL");
            }
        }
    }
}
