using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASoul : MonoBehaviour
{
    private Animator anim;
    private bool isCol = false;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isCol)
        {
            if(!isDead)
                StartCoroutine(Death());
            isDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Players")
        {
            if(!isCol)
                EventCenter.Instance.InvokeEvent("ASoulMusic");
            anim.SetTrigger("isTouched");
            isCol = true;
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
