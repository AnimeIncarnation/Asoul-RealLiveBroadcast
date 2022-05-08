using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableIce : MonoBehaviour
{
    private GameObject hotPot;


    void Start()
    {
        StartCoroutine(TestFire());
    }

    IEnumerator TestFire()
    {
        while (true)
        {
            hotPot = GameObject.Find("HotPot(Clone)");
            if (hotPot != null)
            {
                print("找到了");
                if (Mathf.Abs(transform.position.x - hotPot.transform.position.x) < 0.5 && (transform.position.y - hotPot.transform.position.y) < 5)
                {
                    Destroy(gameObject);
                }

            }
            else
            {
                print("没找到");
            }
            yield return new WaitForSeconds(1);
        }
        
    }
}
