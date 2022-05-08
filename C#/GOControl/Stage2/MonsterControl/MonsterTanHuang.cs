using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTanHuang : MonsterBase
{
    
    public Collider2D col;
    public LayerMask layer;

    void Update()
    {
        Death();
        if (life <= 0)
        {
            TiaoYue();
        }
    }


    void TiaoYue()
    {
        if (col.IsTouchingLayers(layer))
        {
            print("Åöµ½½ÇÉ«");
            float y1 = XiangWanControl2.instance.gameObject.transform.position.y - transform.position.y;
            float x1 = Mathf.Abs(XiangWanControl2.instance.gameObject.transform.position.x - transform.position.x);
            float y2 = JiaLeControl.instance.gameObject.transform.position.y - transform.position.y;
            float x2 = Mathf.Abs(JiaLeControl.instance.gameObject.transform.position.x - transform.position.x);
            //print(y1);
            if (y1 > 3&&x1<1)
            {
                print("IsCai");
                anim.SetTrigger("IsCai");
            }
            if (y2 > 3&&x2<1)
            {
                print("IsCai");
                anim.SetTrigger("IsCai");
            }
        }
    }
}
