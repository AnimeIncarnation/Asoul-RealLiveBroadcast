using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanHuang : MonoBehaviour
{
    Collider2D col;
    public LayerMask layer;
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
    }
    void TiaoYue()
    {
        print("���ɹֶ����¼�");

            print("���ɹֶ����¼� ��һ��");
            //xӦ����0.6-1.1���ң�y����3.4����
            float y1 = XiangWanControl2.instance.gameObject.transform.position.y - transform.position.y;
            float y2 = JiaLeControl.instance.gameObject.transform.position.y - transform.position.y;
            float x1 = Mathf.Abs(XiangWanControl2.instance.gameObject.transform.position.x - transform.position.x);
            float x2 = Mathf.Abs(JiaLeControl.instance.gameObject.transform.position.x - transform.position.x);

        print(x1);
        print(y1);
        print(x2);
        print(y2);
            if (y1>2&&y1<4.5&&x1<1.2&&x1>0)
            {
                print("��ȥ����");
                print(y1);
                print(x1);
                XiangWanControl2.instance.GetComponent<Rigidbody2D>().velocity += new Vector2(0,20);
            }
             if (y2 > 2 && y2 < 4.5 && x2 < 1.2 && x2 > 0)
            {
                JiaLeControl.instance.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 20);
            }

    }
}
