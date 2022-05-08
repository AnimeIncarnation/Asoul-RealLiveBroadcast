using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase:MonoBehaviour
{
    public float life;
    public Rigidbody2D rd;
    public Collider2D swordColXW;
    public Collider2D swordColJL;
    public Animator anim;
    public float force;


    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (life > 0)
        {
            if (col == swordColXW)
            {
                if (XiangWanControl2.instance.transform.position.x < transform.position.x)
                {
                    //rd.velocity += new Vector2(3, 0);
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(force, 0));
                }
                else
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(-force, 0));
                }
                life -= 1;
                XiangWanControl2.instance.swordLife -= 1;
                StartCoroutine(Blink(gameObject));
            }
            else if (col == swordColJL)
            {
                if (JiaLeControl.instance.transform.position.x < transform.position.x)
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(force, 0));
                }
                else
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(-force, 0));
                }
                life -= 2;
                JiaLeControl.instance.swordLife -= 0.2f;
                StartCoroutine(Blink(this.gameObject));
            }
        }
    }

    protected virtual void Death()
    {
        if (life <= 0)
        {
            anim.SetTrigger("IsDead");
        }
    }

    

    void Update()
    {

        Death();
    }

    public IEnumerator Blink(GameObject go, float interval = 0.08f, int times = 6)
    {
        print("½øÈëÐ­³Ì");
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        for (int temp = 0; temp < times; ++temp)
        {
            print(sr.enabled);
            sr.enabled = !sr.enabled;
            print(sr.enabled);
            yield return new WaitForSeconds(interval);
        }
        go.SetActive(true);
    }
}
