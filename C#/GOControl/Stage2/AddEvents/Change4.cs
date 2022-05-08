using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change4 : MonoBehaviour
{
    public GameObject boss;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Players")
        {
            StartCoroutine(Yun());
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator Yun()
    {
        boss.transform.eulerAngles = new Vector3(0, 0, 90);
        boss.GetComponent<Animator>().enabled = false;
        boss.GetComponent<MonsterBoss>().isYun = true;

        yield return new WaitForSeconds(8);
        boss.transform.eulerAngles = new Vector3(0, 0, 0);
        boss.GetComponent<Animator>().enabled = true;
        boss.GetComponent<MonsterBoss>().isYun = false;
    }
}
