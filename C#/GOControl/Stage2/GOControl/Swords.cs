using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
    public float life = 10;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "œÚÕÌ2")
        {
            if (!XiangWanControl2.instance.swordsGet)
            {
                XiangWanControl2.instance.swordsGet = true;
                XiangWanControl2.instance.swordLife = life;
                Destroy(gameObject);
            }
            
        }
        else if (col.gameObject.name == "ÁÏ¿÷")
        {
            if (!JiaLeControl.instance.swordsGet)
            {
                JiaLeControl.instance.swordsGet = true;
                JiaLeControl.instance.swordLife = life;
                Destroy(gameObject);
            }
        }
    }
}
