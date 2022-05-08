using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianCi : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Players")
        {
            if (col.gameObject.name == "œÚÕÌ2")
            {
                EventCenter.Instance.InvokeEvent("CharactorDamageXW");
            }
            else if (col.gameObject.name == "ÁÏ¿÷")
            {
                EventCenter.Instance.InvokeEvent("CharactorDamageJL");
            }
        }

        if (col.gameObject.tag == "Monsters")
        {
            col.gameObject.GetComponent<MonsterBase>().life -= 1;
            StartCoroutine(col.gameObject.GetComponent<MonsterBase>().Blink(col.gameObject));
        }
    }
}
