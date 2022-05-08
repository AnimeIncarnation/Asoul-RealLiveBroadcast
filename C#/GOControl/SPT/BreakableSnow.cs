using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSnow : MonoBehaviour
{
    public int yuzhi;
    public GameObject breakableSnow;


    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Players")
        {
            print(player.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (player.gameObject.GetComponent<Rigidbody2D>().velocity.y <= yuzhi)
            {
                Destroy(breakableSnow);
                Destroy(gameObject);
            }
        }
    }
}
